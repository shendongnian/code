    protected void GetBlob(string blobId)
        {
    string url = "https://api.truevault.com/v1/vaults/" + vaultId + "/blobs/" + blobId;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "*/*";
            request.Method = WebRequestMethods.Http.Get;
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(apiKey + ":")));
    
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
            BinaryReader streamReader = new BinaryReader(response.GetResponseStream());
            //string html = Convert.ToString(streamReader.ReadInt32());
            const int bufferSize = 4096;
            byte[] test;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = streamReader.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                test = ms.ToArray();
            }
    
    
            string file = Convert.ToString(response.Headers["Content-Disposition"]);
            string[] str = file.Split('=');
            string filename = str[1];
            //  Byte[] bytes = streamReader.ReadBytes(int.MaxValue);
            //Byte[] bytes = Encoding.UTF8.GetBytes(html);
            Response.Buffer = true;
            Response.Charset = "";
            response.Close();
            streamReader.Close();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/jpg/png/gif/pdf/ppt/xlx/docx";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            
            Response.BinaryWrite(test);
            Response.Flush();
            Response.End();
    }
