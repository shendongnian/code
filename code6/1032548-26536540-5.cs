    public class RawResponse : Response
    {
        public bool? success {get;set}
        public int? affectedRows {get;set;}
    
        public int? ID {get;set;}
        public int? SomeOtherID {get;set;}
        public string StringValue {get;set;}
        public string DateTime {get;set;}
        
        public RawResponse[] data {get;set;}
    
        public Response ToResponse()
        {
            if(ID.HasValue && SomeOtherID.HasValue && StringValue.)
                return new OtherIdResponse{
                                               ID = ID, 
                                               SomeOtherID = SomeOtherID, 
                                               StringValue = StringValue
                                          };
            if(ID.HasValue && DateTime.HasValue)
                return new DateTimeResponse{ID = ID, DateTime = DateTime};
            //default case; success and child data with optional affectedRows
            return new CompoundResponse{
                                           success = success, 
                                           affectedRows = affectedRows, // can be null 
                                           data = data.Select(d=>d.ToResponse())
                                                     .ToArray()
                                       };            
        }
    }
