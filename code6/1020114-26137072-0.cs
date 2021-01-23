    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace DummyTest
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            static int pom;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack == false)
                {
                   pom = 0;
                   Label1.Text = Convert.ToString(pom);
                }
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
               var pom = Int32.Parse(Label1.Text);
               pom++;
               Label1.Text = Convert.ToString(pom);
            }
            protected void Button2_Click(object sender, EventArgs e)
            {
               var pom = Int32.Parse(Label1.Text);
               pom--;
               Label1.Text = Convert.ToString(pom);
            }
        }
    }
