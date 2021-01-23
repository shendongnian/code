    public class OrdersVM
    {
            public DisplayOneVM DisplayOne { get; set; }
            public DisplayTwoVM DisplayTwo { get; set; }
            
            public class DisplayOneVM
            {
                public int Prop1 { get; set; }
                public bool Prop2 { get; set; }
                public bool Prop3 { get; set; }
                public bool Prop4 { get; set; }
                public bool Prop5 { get; set; }
            }
            public class DisplayTwoVM
            {
                public DateTime Prop1 { get; set; }
                public string Prop2 { get; set; }
                public string Prop3 { get; set; }
                public string Prop4 { get; set; }
                public string Prop5 { get; set; }
            }
    }
