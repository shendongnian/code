    public class ScriptMoverUserControl : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ContentPlaceHolder c = Page.Master.FindControl("ScriptsPlace") as ContentPlaceHolder;
            HtmlGenericControl jsDiv = this.FindControl("_jsDiv") as HtmlGenericControl;
            if (c != null && jsDiv != null)
            {
                jsDiv.ID = Guid.NewGuid().ToString(); //change the ID to avoid ID conflicts if more than one control on page is using this.
                c.Controls.Add(jsDiv);
            }
        }
    }
