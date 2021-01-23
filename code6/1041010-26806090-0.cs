    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn.Text = "Refreshed";
            if (Request.Params["btnPressed"] != null && Request.Params["btnPressed"] == "true")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", string.Format("$('#{0}').click()", btn.ClientID), true);
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            btn.Text = "Not Refreshed";
            lbl.Text = "Not Refreshed";
            System.Threading.Thread.Sleep(1000);
            ////to refresh the page
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString()+"?btnPressed=true", true);
        }
    }
