     [HttpPost]
        public object Dict(Dictionary<int, List<int>> sendedData)
        {
           var d1 = Request.Content.ReadAsStreamAsync().Result;
           var rawJson = new StreamReader(d1).ReadToEnd();
           sendedData=Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(rawJson);
    
        }
