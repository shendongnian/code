        protected void Page_Load(object sender, EventArgs e)
          {
        string file_name = Request.QueryString["file"];
        string path = Server.MapPath("Print_Files/"+file_name);
        // Open PDF File in Web Browser 
        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);
        if (buffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }
     }
