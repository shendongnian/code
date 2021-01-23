    using System;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected double test;
            protected void Page_Load(object sender, EventArgs e)
            {
                test = 12.50;
    
                test1.Value = test.ToString();
            }
        }
    }
