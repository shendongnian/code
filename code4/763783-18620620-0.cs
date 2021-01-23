    // Another simple way would be to create a class which has a constructor to hold the three strings
        public class PairedValues
        {
            public string value1 { get; set; }
            public string value2 { get; set; }
            public string value3 { get; set; }
    
            public PairedValues(string Value1, string Value2, string Value3)
            {
                value1 = Value1;
                value2 = Value2;
                value3 = Value3;
            }
        }
