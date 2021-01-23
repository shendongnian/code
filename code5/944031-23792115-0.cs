    HttpClient c = new HttpClient();
    var response = await c.GetAsync(yoururl);
    var newsResult = await response.Content.ReadAsAsync<NewsResult>();
---
    public class NewsResult
    {
        public Dictionary<string, Item> result { set; get; }
    }
    public class Item
    {
        public string id { set; get; }
        public string title { set; get; }
    }
