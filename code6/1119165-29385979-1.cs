    public class ClassName
    {
        public ClassName()
        {
           this.PropertyName = new Dictionary<string, object>();
        }
        
        public Dictionary<string, object> PropertyName {get; set; }
    }
    
    var c = new ClassName();
    c.PropertyName.Add("stringKey", anyValue);
