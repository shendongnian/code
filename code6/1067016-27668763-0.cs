    public class MyData
    {
       public string name {get;set;}
    }
    var dictionary =  JsonConvert.DeserializeObject<Dictionary<string,MyData>>(jsonString);
    var myData = dictionary["MyData"];
