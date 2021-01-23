    using (var client = new WebClient())
                {                
                     
                    var fileToConvert = "c:\file-to-convert.docx";
                    
                   
                    var data = new NameValueCollection();                
                                     
                    data.Add("ApiKey", "413595149"); 
                   
                    try
                    {                    
                        client.QueryString.Add(data);
                        var response = client.UploadFile("http://do.convertapi.com/word2pdf", fileToConvert);                    
                        var responseHeaders = client.ResponseHeaders;                    
                        var path = Path.Combine(@"C:\", responseHeaders["OutputFileName"]);
                        File.WriteAllBytes(path, response);
                        Console.WriteLine("The conversion was successful! The word file {0} converted to PDF and saved at {1}", fileToConvert, path);
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine("Exception Message :" + e.Message);
                        if (e.Status == WebExceptionStatus.ProtocolError)
                        {
                            Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                            Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                        }
     
                    }
     
     
                }
