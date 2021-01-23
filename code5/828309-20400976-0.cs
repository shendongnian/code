     public class Child
            {
                public string task { get; set; }
                public double duration { get; set; }
                public string user { get; set; }
                public bool leaf { get; set; }
                public string iconCls { get; set; }
                public List<Child> children { get; set; }
            }
            
            public class Tree
            {
                public string text { get; set; }
                public List<Child> children { get; set; }
            }
