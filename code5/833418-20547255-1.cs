    public class ScriptMoverUserControl : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ContentPlaceHolder c = Page.Master.FindControl("ScriptsPlace") as ContentPlaceHolder;
            HtmlGenericControl jsDiv = this.FindControl("_jsDiv") as HtmlGenericControl;
            if (c != null && jsDiv != null)
            {
                c.Controls.Add(jsDiv);
            }
        }
    }
