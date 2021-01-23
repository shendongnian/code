    WebClient client = new WebClient();
    byte[] imageData = client.DownloadData(yourimageurl);
    Response.ContentType = ContentType;
    Response.AppendHeader("Content-Disposition", "attachment; filename=" fileName);
    Response.ContentType = "image/JPEG";
    Response.OutputStream.Write(imageData, 0, imageData.Length);
    Response.End();
