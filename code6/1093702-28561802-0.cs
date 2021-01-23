	string json = "{\"Method\":\"LOGIN\",\"Skill\":{\"1\":\"SKILL-1\",\"2\":\"SKILL-2\"}}";
    var oSerializer = new JavaScriptSerializer();
    var dict = oSerializer.Deserialize<Dictionary<string,object>>(json);
    var innerDict = dict["Skill"] as Dictionary<string, object>;
    
    if (innerDict != null)
    {
       foreach (var kvp in innerDict)
       {
    	   Console.WriteLine ("{0} = {1}", kvp.Key, kvp.Value);
       }
    }
