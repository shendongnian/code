    public class MyBasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Title = this.Title + " - MySite";
        }
    }
