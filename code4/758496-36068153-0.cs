    protected void btnDownload_Click(object sender, EventArgs e)
            {
                string FileName = "Durgesh.jpg"; // Its a file name displayed on downloaded file on client side.
    
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "image/jpeg";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(Server.MapPath("~/File/001.jpg"));
                response.Flush();
                response.End();
            }
 
