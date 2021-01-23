    using System;
    
    namespace SOTest1
    {
        public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                string mystring = Request.QueryString["mystring"];
                myAnchor.HRef = mystring;
                myAnchor.InnerText = mystring;
            }
        }
    }
