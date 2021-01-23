    var myDict = new Dictionary<string, Dictionary<string, string>>();
    
    var innerDict = new Dictionary<string, string>();
    innerDict.Add("name", "name 0");
    innerDict.Add("value", "value 0");
    
    myDict.Add("0", innerDict);
    
    innerDict = new Dictionary<string, string>();
    innerDict.Add("name", "name 1");
    innerDict.Add("value", "value 1");
    
    myDict.Add("1", innerDict);
    
    var foo = myDict["0"]["name"]; // returns "name 0"
    
    string json = Newtonsoft.Json.JsonConvert.SerializeObject(myDict);
