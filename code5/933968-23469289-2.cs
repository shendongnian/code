    var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(urlPicturesBig + urlresource);
            Byte []bytes;
            using (var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                var stream = httpWebReponse.GetResponseStream();
                var length = stream.Length;
                bytes = new byte[length];
                //read the entire stream into memory to ensure any network issues
                //are exposed
                stream.Read(bytes, 0, bytes.Length);
            }
            var tmpimg = System.Drawing.Image.FromStream(new MemoryStream(bytes)));            {
            tmpimg.Save(@appDirectory + "\\resources\\" + urlresource);    
