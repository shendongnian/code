    class MyDataObject
    {
       public string Data1{get;set;}
       [...]
    }
    string jsonText = ...;
    var dataObject = JsonConvert.DeserializeObject<MyDataObject>(jsonText);
    var myData = dataObject.Data1;
