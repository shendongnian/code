    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    public partial class Description : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //For Response.Redirect - do this
            //string username = Request.QueryString["Username"];
            //string password = Request.QueryString["Password"];
            //lblResult.Text = "Username : " + " Password : " + password;
            
            //Below is for Server.Transfer() 
            if (Page.PreviousPage != null)
            {
                TextBox SourceTextBox_1 =
                    (TextBox)Page.PreviousPage.FindControl("txtUsername");
                TextBox SourceTextBox_2 =
                   (TextBox)Page.PreviousPage.FindControl("txtPassword");
                if (SourceTextBox_1 != null)
                {
                    lblResult.Text = SourceTextBox_1.Text + " " + SourceTextBox_2.Text ;
                }
            }
        }
    }
