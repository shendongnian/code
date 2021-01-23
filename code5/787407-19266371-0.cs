    [DataContract]
    [KnownType(typeof(ResponseType1))]
    [KnownType(typeof(ResponseType2))]
    public class BaseResponseType
    {
        ...
    }
    
    [DataContract]
    public class ResponseType1: BaseResponseType
    {
        ...
    }
    
    [DataContract]
    public class ResponseType2: BaseResponseType
    {
        ...
    } 
