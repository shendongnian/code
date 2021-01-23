    [Serializable()]
    public class Info
    {
     private int _id;
    
     private List<Info> _children;
     public int Id {
      get { return _id; }
      set { _id = value; }
     }
    
     public List<Info> Children {
      get { return _children; }
      set { _children = value; }
     }
    
    }
    
    
    public void Main()
    {
     string json = null;
     List<Info> result = null;
     System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
    
     json = "[{\"id\":1},{\"id\":2,\"children\":[{\"id\":3},{\"id\":4,\"children\":[{\"id\":5,\"children\":[{\"id\":6}]}]},{\"id\":7}]}]";
    
     result = ser.Deserialize<List<Info>>(json);
    
     foreach (Info p in result) {
      Console.WriteLine(p.Id);
    
      if (p.Children != null) {
       foreach (Info c in p.Children) {
        Console.WriteLine("   " + c.Id);
       }
      }
     }
    
     Console.ReadLine();
    
    }
