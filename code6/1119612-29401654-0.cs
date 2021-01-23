            var ds = new DataSet();
            WebRequest request = WebRequest.Create(requestUriString);
            request.Method = "GET";
            using (var response = (System.Net.HttpWebResponse)request.GetResponse())
            {
                // get correct charset and encoding from the server's header
                Encoding encoding;
                try
                {
                    encoding = Encoding.GetEncoding(response.CharacterSet);
                }
                catch
                {
                    encoding = Encoding.UTF8;
                }
                using (var rdr = new StreamReader(response.GetResponseStream(), encoding))
                {
                    ds.ReadXml(rdr);
                }
            }
