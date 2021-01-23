    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication2
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {        
                GridView1.DataBind();
            }
            protected void btnShow_Click(object sender, EventArgs e)
            {
                var data = new Dictionary<int, string>();
                data.Add(1, "John");
                data.Add(2, "Bob");
                GridView1.DataSource = data;  
                GridView1.DataBind();
            }
            protected void btnHide_Click(object sender, EventArgs e)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
    }   
