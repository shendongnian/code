    try
            {
                var r = (HttpWebRequest)WebRequest.Create("/S");
                r.Method = "POST";
                r.ContentType = @"text/json; charset=utf-8; action=""Invalid:S.O.A.P.:Action...""";
                var js = new JavaScriptSerializer();
                string postData = js.Serialize(new {something = "Hello World"});
                r.ContentLength = postData.Length;
                var ws = new StreamWriter(r.GetRequestStream());
                ws.Write(postData);
                ws.Close();
                var resp = (HttpWebResponse)r.GetResponse();
                
                var respStream = resp.GetResponseStream();
                if (respStream == null) return;
                var sr = new StreamReader(respStream);
                string s = sr.ReadToEnd();
            }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    {
                        if (stream == null) return;
                        using (var reader = new StreamReader(stream))
                        {
    //At this point i'm just writing it to the console. However her you have your FaultException xml encoded.
                            Console.WriteLine(reader.ReadToEnd());
                        }
                    }
                }
