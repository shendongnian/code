    using (var client = new WebClient { UseDefaultCredentials = true })
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/xml; charset=utf-8");
                    byte[] responseArray = client.UploadData("URL of web API", "POST", Encoding.UTF8.GetBytes(XMLText));
                    string response = Encoding.ASCII.GetString(responseArray);
                }
