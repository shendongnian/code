    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace DFM.Dashboard
    {
        public partial class Dashboard : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                
            }
      
            protected void btnGnetworkTools_Click(object sender, EventArgs e)
            {
                Response.Redirect("~/Microsites/Dashboard.aspx");
            }
            public override void VerifyRenderingInServerForm(Control control)
            {
                /* Verifies that the control is rendered */
            }
        }
}
