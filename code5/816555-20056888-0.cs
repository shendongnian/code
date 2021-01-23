    public class OuterObject
    {
         public FirstArrayObject[];
         public List<ObjInNestedArray[]>;
    }
    
    public class FirstArrayObject
    {
       public string A;
       public string B;
       public string C;
    }
    
    public class ObjInNestedArray
    {
         string property1;
         AnotherLevel AnotherLevel;
         
    }
    
    public class AnotherLevelObj
    {
          string prop1;
    }
    
    OuterObject response = JsonConvert.DeserializeObject<OuterObject>(responseBodyAsString);
