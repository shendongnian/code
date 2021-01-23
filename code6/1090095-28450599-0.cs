     public class Rootobject
            {
                public Class1[] Property1 { get; set; }
            }
    
            public class Class1
            {
                public string Title { get; set; }
                public int Priority { get; set; }
                public Attribute[] attributes { get; set; }
            }
    
            public class Attribute
            {
                public string Title { get; set; }
                public string Value { get; set; }
                public int Priority { get; set; }
            }
