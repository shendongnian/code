    class JsonDataManager
    {
        String url = "http://www.kaanbarisbayrak.com/?json=get_category_posts&cat=";
        string data = "";
        HttpClient hc;
    
        public JsonDataManager(string Category)
        {
            hc = new HttpClient();
            url += Category;
        }
    
        public Task<string> getWriting()
        {
            return Task.Factory.StartNew<string>(() =>
            {
                data = hc.GetStringAsync(url).Result;
    
                // use the resulting string
                JObject obj = JObject.Parse(data);
                JArray array = (JArray)obj["posts"];
                string writing = (string)array[0]["content"];
                return writing;
            });
        }
    }
---
        private void Form1_Load(object sender, EventArgs e)
        {
            JsonDataManager manager = new JsonDataManager("4");
            manager.getWriting().ContinueWith((task) =>
            {
                string writing = task.Result;
                MessageBox.Show(writing);
            });
        }
