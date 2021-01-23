     public class StringCollection
        {
            public string StringProp1 { get; set; }
            public string StringProp2 { get; set; }
            public string StringProp3 { get; set; }
            public string StringProp4 { get; set; }
    
            public int SomeOtherProperty { get; set; }
        }
    
    
        public class SomeOtherClass
        {
            public string a1 { get; set; }
            public string a2 { get; set; }
            public string a3 { get; set; }
    
            public DateTime d1 { get; set; }
            public int SomeOtherProperty { get; set; }
        }
    
        public static class MyExtensions
        {
            public static void ClearStrings(this Object obj)
            {
                // returns all public properties
                foreach (var prop in obj.GetType().GetProperties())
                {
                    // "clear" only properties of type String and those that have a public setter
                    if (prop.PropertyType == typeof(string) && prop.CanWrite)
                        prop.SetValue(obj, string.Empty, null); // <- "clear" value of the property 
                }
            }
        } 
