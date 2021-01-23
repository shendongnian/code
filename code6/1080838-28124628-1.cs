    public class OrdersVM
    {
            public FirstDisplayVM FirstDisplay { get; set; }
            public SecondDisplayVM SecondDisplay { get; set; }
            
            public class FirstDisplayVM
            {
                public int Prop1 { get; set; }
                public List<bool> MyBooleanValues { get; set; }
            }
            public class SecondDisplayVM
            {
                public int Prop1 { get; set; }
                public List<string> MyStringValues { get; set; }
            }
    }
