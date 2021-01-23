	public partial class TestImagePreviewAndUpload : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		protected void Upload_Clicked(object sender, EventArgs e)
		{
			if(pictureOfMe.PostedFile.FileName != string.Empty) {
				byte[] uploadedBytes = pictureOfMe.FileBytes;
				//save uploaded picture here
			}
		}
	}
