    public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var ctrl = (sTextBox) Page.LoadControl("~/sTextBox.ascx");
			ctrl.Text = "something";
			placeHolder1.Controls.Add(ctrl);
		}
	}
