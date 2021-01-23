    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication
    {
        public partial class TreeTest : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void tvTest_SelectedNodeChanged(object sender, EventArgs e)
            {
                Response.Redirect("~/Display.aspx", true);
            }
        }
    }
