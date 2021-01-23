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
                if(!IsPostBack)
                {
                     Label1.Text = Request.QueryString["Event"] == null ? "" : Request.QueryString["Event"]; 
                }
            }
        }
    }
    
