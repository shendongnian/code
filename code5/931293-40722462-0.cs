    var url = "myurl.com/filename.jpg"
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
    using (HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse())
    using (Stream responseStream = HttpWResp.GetResponseStream())
    using (MemoryStream ms = new MemoryStream())
    {
        responseStream.CopyTo(ms);
        ms.Seek(0, SeekOrigin.Begin);
        Attachment attachment = new Attachment(ms, filename, MediaTypeNames.Image.Jpeg);
        message.Attachments.Add(attachment);
        _smtpClient.Send(message);
    }
