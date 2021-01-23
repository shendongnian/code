        var theWebRequest = HttpWebRequest.Create("http://localhost:51045/Default.aspx/Senddata");
                    theWebRequest.Credentials = new NetworkCredential(tobj.Username, tobj.Password,tobj.propertyID);
                    theWebRequest.Method = "POST";
                    theWebRequest.ContentType = "application/json; charset=utf-8 ";
                    //theWebRequest.Headers.Add(HttpRequestHeader.Pragma.ToString, "no-cache");
                    using (var writer = theWebRequest.GetRequestStream())
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            something = value                    
                        });
        
                        var data = Encoding.UTF8.GetBytes(json);
        
                        writer.Write(data, 0, data.Length);
                        writer.Flush();
                        writer.Close();
                    }
        
                    var theWebResponse = (HttpWebResponse)theWebRequest.GetResponse();         
                    var theResponseStream = new StreamReader(theWebResponse.GetResponseStream());
                    string result = theResponseStream.ReadToEnd().ToString();
       var data1 = new JavaScriptSerializer().DeserializeObject(result);
