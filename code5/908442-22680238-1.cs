    public async static Task<string> GetResponse(string url)
            {
                try
                {
                    WebRequest request = HttpWebRequest.Create(url);
                    request.ContentType = "application/xml";
                    WebResponse response = await request.GetResponseAsync();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string content = reader.ReadToEnd();
                    reader.Dispose();
                    response.Dispose();
                    return content;
                }
                catch
                {
                    return "";
                }
            }
