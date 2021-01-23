    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            public string src = "";
    
            protected void Page_Load(object sender, EventArgs e)
            {
                src = "~/1455094_265560366930522_537876922_n.jpg";
                //Add this
                Page.DataBind();
            }
        }
    }
