    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000000000; i++)
            {
                 //just a codeblock to make it load long, replace with yours.
            }
            Response.Redirect("Default.aspx");
        }
    }
