    public class Dat
    {
    public int data { get; set; }
    }
     public class Info
     {
      public List<Dat> dat { get; set; }
     }
    public class Attr
    {
     public Info info { get; set; }
    }
     public class RootObject
     {
       public int id { get; set; }
      public Attr attr { get; set; }
     }
     string sValue = "{id: 123,attr: {info: {dat: [{data:1}, {data:2}]}}}";
            System.Web.Script.Serialization.JavaScriptSerializer ObjJSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var Data = ObjJSerializer.Deserialize<RootObject>(sValue);
