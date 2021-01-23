    public string PostJson(string url,string json)
            {
    	    WebRequest request = WebRequest.Create(url);
    
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
    
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
    	    Console.Writeline(string.Format("Request {0} Response Code {1} Resonse Status Description {2} Response From Server {3}",
                                              json, ((HttpWebResponse)response).StatusCode,
                                             ((HttpWebResponse)response).StatusDescription, responseFromServer));
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
            }
