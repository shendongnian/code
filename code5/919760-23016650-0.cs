    public class JsonDataManager
    {
       String myData = "its going to be filled by json";
       ManualResetEvent mre = new ManualResetEvent(false);
       
       public JsonDataManager(string Category)
       {
           String url = "<a href="http://www.kaanbarisbayrak.com/?json=get_category_posts&cat="+Category;<br">http://www.kaanbarisbayrak.com/?json=get_category_posts&cat="+Catego...</a> />
           WebClient wc = new WebClient();
           wc.Encoding = System.Text.Encoding.UTF8;
           wc.Headers["Accept"] = "application/json";
           wc.DownloadStringAsync(new Uri(url), UriKind.Relative);
           wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
       }
    
       public String getWriting()
       {
       	   mre.WaitOne();
           JObject obj = JObject.Parse(myData);
           JArray array = (JArray)obj["posts"];
           string writing = (string)array[0]["content"]; 
           return writing;
       }
    
       private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
       {
           myData = e.Result;
    	   mre.Set();
       }
    }
