    var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(urlPicturesBig + urlresource);
            Byte []bytes;
            using (var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                var stream = httpWebReponse.GetResponseStream();
                var length = stream.Length;
                bytes = new byte[length];
                stream.Read(bytes, 0, bytes.Length);
            }
            var tmpimg = System.Drawing.Image.FromStream(new MemoryStream(bytes)));            {
            tmpimg.Save(@appDirectory + "\\resources\\" + urlresource);    
