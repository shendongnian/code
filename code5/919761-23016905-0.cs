    public class JsonDataManager
    {
        readonly String _url;
        public JsonDataManager(string category)
        {
            _url = @"http://www.kaanbarisbayrak.com/?json=get_category_posts&cat="+category;
        }
        public async Task<String> getWriting()
        {
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            wc.Headers["Accept"] = "application/json";
            JObject obj = JObject.Parse(await wc.DownloadStringTaskAsnync(_url));
            JArray array = (JArray)obj["posts"];
            string writing = (string)array[0]["content"]; 
            return writing;
        }
    }
