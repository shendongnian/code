    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    public partial class _Default : System.Web.UI.Page 
    {
        string s1, s2;
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            s1 = txtUsername.Text;
            s2 = txtPassword.Text;
            if ((s1 == "sa") && (s2 == "123qwe"))
            {
                /*
                 * Passing data using QueryString.
                 */
                //Response.Redirect("Description.aspx?Username=&Password=" + s1 + " " + s2);
                Server.Transfer("Description.aspx?Username=&Password=" + s1 + " " + s2);
            }
            else
            {
                lblMessage.Text = "Invalid Username and Password";
            }
        }
    }
