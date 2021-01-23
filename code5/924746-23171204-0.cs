    WebClient client = new WebClient();
    var json = client.DownloadString("http://www.test.com/api/surveys/?api_key=123");
    Debug.WriteLine(json); //write all data from json
    
    //add
    var example = JsonConvert.DeserializeObject<Survey>(json);
    Debug.WriteLine(example.length); // this could be count() instead.
    
    class Survey
    {
        public string title { get; set; }
        public int id { get; set; }
    }
