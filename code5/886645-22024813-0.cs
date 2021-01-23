    var urlstring = "http://api.xxx.com/users/" + Username.Text;
    var MyClient = WebRequest.Create(urlstring) as HttpWebRequest;
    //Assuming your using http get.  If not, you'll have to do a bit more work.
    MyClient.Method = WebRequestMethods.Http.Get;
    MyClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
    MyClient.Headers.Add(HttpRequestHeader.UserAgent, "DIMS /0.1 +http://www.xxx.dk");
    var response = MyClient.GetResponse() as HttpWebResponse;
    
    for (int i = 0; i < response.Headers.Count; i++ )
         Console.WriteLine(response.Headers.GetKey(i) + " -- " + response.Headers.Get(i).ToString());
