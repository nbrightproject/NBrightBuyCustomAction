using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using DotNetNuke.Entities.Portals;
using NBrightDNN;
using Nevoweb.DNN.NBrightBuy.Components;

namespace Nevoweb.DNN.NBrightBuy.Providers
{
    public class CustomAction : Components.Interfaces.CustomActionInterface
    {
        public override string Run(string paramdata)
        {
            // Custom Action providers are designed to run a 1 time update of data, in the DB, without the need of a UI.
            // Usually a selection of data records from the DB will be done and then an action and update performed.
            // The example below is showing the selection of products in the system and a simple alteration of data.
            // No update is done with this example.

            // The resulting dll from this project can be copied into the /bin folder of the DNN/NBS installation and then ran using the BO>Admin>Tools option.
            // e.g. for this provider name. (Alter as required)
            // assembly: NBrightBuy.BaseCustomAction
            // namespace.class: Nevoweb.DNN.NBrightBuy.Providers.CustomAction

            // NOTE: change the namespace of "Nevoweb." and the assembly name.

            var objCtrl = new NBrightBuyController();

            var list = objCtrl.GetList(PortalSettings.Current.PortalId, -1, "PRD");

            foreach (var nbi in list)
            {
                var data = nbi.GetXmlProperty("genxml/testdata");
                data = data + "testing";
                nbi.SetXmlProperty("genxml/testdata",data);
                //objCtrl.Update(nbi); // apply updated record back to DB.
            }

            return "";
        }
    }
}
