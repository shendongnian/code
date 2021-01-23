    var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(urlPicturesBig + urlresource);
    MemoryStream memory= new MemoryStream();
    using (var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
    {
         var stream = httpWebReponse.GetResponseStream();
         //read the entire stream into memory to ensure any network issues
         //are exposed
         stream.CopyTo(memory);
    }
    var tmpimg = System.Drawing.Image.FromStream(memory);            {
    tmpimg.Save(@appDirectory + "\\resources\\" + urlresource);    
