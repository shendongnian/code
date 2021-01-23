     public partial class ErrorPage : System.Web.UI.Page{
            protected void Page_Load(object sender, EventArgs e)
            {
                Exception err = Session["LastError"] as Exception;
                if (err != null)
                {
                    err = err.GetBaseException();
                    lblError.Text = Server.HtmlEncode(err.Message);
                }
            }
        }
