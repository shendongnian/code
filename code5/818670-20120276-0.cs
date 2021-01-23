      public class Item
     {
    public string name { get; set; }
    public bool prop1 { get; set; }
    public string prop2 { get; set; }
    public string prop3 { get; set; }
    public string prop4 { get; set; }
     }
     public class RootObject
    {
    public List<Item> items { get; set; }
    }
    string sValue ="{items:[{name:"item1", prop1:true, prop2:"prop"},{name:"item2", prop1:true, 
                      prop3:"prop", prop4:"prop"}]}
       System.Web.Script.Serialization.JavaScriptSerializer ObjJSerializer = new         
                                             System.Web.Script.Serialization.JavaScriptSerializer();
       var Data = ObjJSerializer.Deserialize<RootObject>(sValue);
