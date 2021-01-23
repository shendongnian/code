     public string GetAllLinks()
                {
                    const string baselink = "http://buzzon.khaleejtimes.com/ad-category/real-estate/page/";
                    //Check if OK status answer from server, page link is valid
                    for (int i = 1; i < 10000; i++)
                    {
                        var url = baselink + i;
                        if (LinkExist(url) != true)
                        {
                          try 
                          {
                            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                            // Sends the HttpWebRequest and waits for a response.
                            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
                          using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                          {
                            if (HttpStatusCode.OK == response.StatusCode)
                            {                           
                              WriteUrl(url);
                              myHttpWebResponse.Close();
                            }
                            else
                               break;
                         }
                      }
                      catch (Exception wex) 
                      {
                         string pageContent = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd().ToString();
                         return pageContent;
                       } 
                    }
                    ParsePages();
                    return "Response Established";
            }
