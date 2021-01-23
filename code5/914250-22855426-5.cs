     [HttpPost]
     public async Task<ActionResult> Check(string jsonData)
     {
    	//use newtonsoft json parser
    	JObject obj = JObject.Parse(jsonData);
    	var listType = obj["listType"].Value<string>();
        if(listType == 'AllocationID')
        {
             var jarr = obj["data"].Value<JArray>();
             List<AllocationID> documents = jarr.ToObject<List<AllocationID>>();
             //do something with documents list...
        }
     } 
