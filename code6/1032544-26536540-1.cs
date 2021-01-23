    public class RawResponse
    {
        public bool? success {get;set}
        public int? affectedRows {get;set;}
    
        public int? ID {get;set;}
        public int? SomeOtherID {get;set;}
        public string StringValue {get;set;}
        public string DateTime {get;set;}
        
        public RawResponse[] data {get;set;}
    }
