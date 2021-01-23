    private static void post()
            {
                System.Net.WebRequest req = null;
                System.Net.WebResponse rsp = null;
                Stream newStream = null;
                try
                {
                    req = System.Net.WebRequest.Create("http://localhost:39384/Default.aspx");
                    req.Method = "POST";
                    req.ContentType = "text/xml";
    
                    newStream = req.GetRequestStream();
                    StreamWriter writer = new System.IO.StreamWriter(newStream);
                    writer.WriteLine("ddd");
                    writer.Flush();
                    writer.Close();
    
                    rsp = req.GetResponse();
                }
                catch(Exception e)
                {
                    throw;
                }
                finally
                {
                    if (req != null) newStream.Close(); // *****Error occures here****
                    if (rsp != null) rsp.GetResponseStream().Close();
                }
            }
