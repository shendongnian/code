    public class WriteBusinessObjectApiFromObjRequest
    {
        public int Pa1 { get; set; }
        public string Pa2 { get; set; }
        public List<Product> Item { get; set; } // change to your Type
    }
    [AcceptVerbs("GET", "POST")]
    [HttpGet]
    public void WriteBusinessObjectApiFromObj(WriteBusinessObjectApiFromObjRequest request)
    {
        // To Do In Function 
    }
    var apiUrl = "api/WriteBusinessObjectApiFromObj";
    var response = client.PostAsJsonAsync(
         apiUrl, 
         new WriteBusinessObjectApiFromObj { Pa1 = 1, Pa2 = "2", Item = obj })
         .Result;
