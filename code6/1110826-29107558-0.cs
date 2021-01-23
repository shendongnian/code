    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace lubna
    {
        public partial class label : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void Button1_Click(object sender,EventArgs e)
            { 
                  Response.Redirect("~/label.aspx?Event=successful");
            }
            protected void Button2_Click(object sender,EventArgs e)
            { 
                  Response.Redirect("~/label.aspx?Event=failure");
            }
        }
    }
