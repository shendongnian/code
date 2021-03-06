    HttpWebResponse res = (HttpWebResponse)HttpWRequest.GetResponse();
    Stream pdfdata = res.GetResponseStream();
    string path = pdfdata.ToString();
        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);
        if (buffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
            Response.End();
        }
