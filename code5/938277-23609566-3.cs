    using System;
    
    namespace WebApp.UserControlExample
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void MyUserControl1_NameChanged(string name)
            {
                Label1.Text = "Selected name is <b>" + name + "</b>";
                //you probably want to call your ClientScript.RegisterStartupScript in here...
            }
        }
    }
