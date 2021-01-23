    using System;
    
    namespace SOTest1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Button1_Click(object sender, EventArgs e)
            {
                string myString = Server.HtmlEncode(TextBox1.Text);
                Response.Redirect("Webform2.aspx?mystring=" + myString);
            }
        }
    }
