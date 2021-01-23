	protected int PageId;
	protected void Page_Load(object sender, EventArgs e)
	{
	    PageId = 12;
		for (int i = 1; i <= 10; i++) 
		{ 
			Image img = MyContainer.FindControl("Image" + i) as Image;
			img.ImageUrl = "ImageCSharp.aspx?ImageID=" + PageId; 
		}
	}
