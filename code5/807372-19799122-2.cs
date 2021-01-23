    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Zzz
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "$('#Image1').fadeOut(3000);", true);
            }
        }
    }
