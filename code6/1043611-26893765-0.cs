     public class yourKeyvalue
        {
            public string _Key{ get; set; }
            public string _value{ get; set; }
          
        }
        
        
        var postData = new JavaScriptSerializer().Deserialize<yourKeyvalue>(data);
        var Key = postData._Key 
        var Value = postData._value
