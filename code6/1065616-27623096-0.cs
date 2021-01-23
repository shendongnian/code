    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        if (AsyncFileUpload1.HasFile)
        {
            string fileName = Server.MapPath("Images/") + Guid.NewGuid().ToString();
            AsyncFileUpload1.SaveAs(fileName);
            Picture_Img.ImageUrl = "~/Images" + Guid.NewGuid().ToString();
        }
    }
