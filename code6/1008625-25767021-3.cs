	public partial class DirectoryCheck : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string x = string.Concat("Physical Directory: ", Common.DirectoryHelpers.FindPhysicalRootDirectory(this.Page));
		}
	}
