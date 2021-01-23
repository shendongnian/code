     public class Parameter
     {
         public string Index { get; set; }
         public dynamic Value { get; set; }
     }
    
     var param1 = new Parameter() { Index = "qw", Value = 34 };
     var param2 = new Parameter() { Index = "qr", Value = "rere" };
    
     int val1 = (int)param1.Value;
     string val2 = (string)param2.Value;
