            public class RootObject
            {
                public Stats stats { get; set; }
                public string response { get; set; }
                public int runtimeMs { get; set; }
            }
            public class Stats
            {
                public Varient X { get; set; }
                public Varient Y { get; set; }
                public Varient Z { get; set; }
            }
            public class Variant
            {
                public string name { get; set; }
                public string Found { get; set; }
            }
            
