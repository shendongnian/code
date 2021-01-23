    protected void btnDownload_Click(object sender, ImageClickEventArgs e)
    {
        string imagepath= GetImagePath();//blah blah, get this from somewhere
        Response.ContentType= "image/JPEG";
        Response.AddHeader("Content-Disposition", "attachment; filename=myimage.jpeg");
        Response.WriteFile(imagepath);
        Response.End();
    }
      
