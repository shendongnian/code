    public class ChartModel
    {
        public string region { get; set; }
        public int projects_finalized { get; set; }
    }
    [HttpPost]
    public ActionResult DataBinding()
    {
        IEnumerable<ChartModel> result = GetData();
        return Json(result);
    }
    public IEnumerable<ChartModel> GetData() {
        string url = "https://solr.fakeURL.com/json";
        WebClient c = new WebClient();
        var json = c.DownloadString(url);
        
        // Do something like this to deserialize the JSON.
        Rootobject result = JsonConvert.DeserializeObject<Rootobject>(jsonString);
        // Here you flatten root object into collection of `ChartModel` objects
        return chartModels;
    }
