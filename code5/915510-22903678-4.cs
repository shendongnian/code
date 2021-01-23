                       var postRequest = (HttpWebRequest)WebRequest.Create("http://74.54.46.178/vertexweb10/webservice.svc/login?username=%22user15650%22&password=%22898k%22");
               
                postRequest.Method = "GET";
                if (sessionCookie == null)
                {
                    postRequest.CookieContainer = new CookieContainer();
                }
                else
                {
                    postRequest.CookieContainer = sessionCookie;
                }
                HttpWebResponse postResponse = (HttpWebResponse)await postRequest.GetResponseAsync();
                if (postResponse != null)
                {
                    var postResponseStream = postResponse.GetResponseStream();
                    var postStreamReader = new StreamReader(postResponseStream);
                    string response = await postStreamReader.ReadToEndAsync();
                    if (sessionCookie == null)
                    {
                        sessionCookie = postRequest.CookieContainer;
                    }
                }
		    var postRequest1 = (HttpWebRequest)WebRequest.Create("http://74.54.46.178/vertexweb10/webservice.svc/getallsymbols?AccountID=1122336675");              
                postRequest1.Method = "GET";
                if (sessionCookie == null)
                {
                    postRequest1.CookieContainer = new CookieContainer();
                }
                else
                {
                    postRequest1.CookieContainer = sessionCookie;
                }
                HttpWebResponse postResponse1 = (HttpWebResponse)await postRequest1.GetResponseAsync();
                if (postResponse1 != null)
                {
                    var postResponseStream1 = postResponse1.GetResponseStream();
                    var postStreamReader1 = new StreamReader(postResponseStream1);
                    string response1 = await postStreamReader1.ReadToEndAsync();
                }
            
