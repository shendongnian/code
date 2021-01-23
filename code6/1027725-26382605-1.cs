    public class StringCollection
    {
        public string StringProp1 { get; set; }
        public string StringProp2 { get; set; }
        public string StringProp3 { get; set; }
        public string StringProp4 { get; set; }
        // .... more properties here
 
        // this property won't be touched when clearing
        public int SomeOtherProperty{ get; set; }
    
        public void ClearStrings()
            {
                // returns all public properties
               foreach (var prop in this.GetType().GetProperties())
            {
                // "clear" only properties of type String and those that have a public setter
                if (prop.PropertyType == typeof(string) && prop.CanWrite) 
                    prop.SetValue(this, string.Empty, null); // <- "clear" value of the property 
            }
        }
