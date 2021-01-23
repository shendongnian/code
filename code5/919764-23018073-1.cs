    public class JsonDataManager
    {
    	Task<string> myData;
    
    	public JsonDataManager(string Category)
    	{
    		this.myData = Task.Factory.StartNew<string>(() => {
    			String url = "<a href="http://www.kaanbarisbayrak.com/?json=get_category_posts&cat="+Category;<br">http://www.kaanbarisbayrak.com/?json=get_category_posts&cat="+Catego...</a> />
    			WebClient wc = new WebClient();
    			wc.Encoding = System.Text.Encoding.UTF8;
    			wc.Headers["Accept"] = "application/json";
    			string result = wc.DownloadString(new Uri(url), UriKind.Relative);
    			return result;
    		});
    	}
    	
    	public String getWriting()
            {
    			// wait for the download task to finish
    			string data = myData.Result;
    			
    			// use the resulting string
                JObject obj = JObject.Parse(data);
                JArray array = (JArray)obj["posts"];
                string writing = (string)array[0]["content"]; 
                return writing;
            }
    	
    }
