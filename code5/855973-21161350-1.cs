    class Container
    {
    	public List<IdField> data{get;set;}
    }
    
    class IdField
    {
    	public string id{get;set;}
    	public string field{get;set;}
    }
    
    
    string s1 = "{ \"data\": [{ \"id\": \"id1\", \"field\": \"field1\" }], \"paging\": { \"prev\": \"link1\", } }";
    string s2 = "{ \"data\": [{ \"id\": \"id2\", \"field\": \"field2\" }], \"paging\": { \"prev\": \"link2\", } }";
    
    var d1 = JsonConvert.DeserializeObject<Container>(s1);
    var d2 = JsonConvert.DeserializeObject<Container>(s2);
    	
    d1.data.AddRange(d2.data);
    	
    var result = JsonConvert.SerializeObject(d1);
