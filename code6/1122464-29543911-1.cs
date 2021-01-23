        [BsonIgnoreExtraElements]
        [BsonDiscriminator(RootClass = true)]
        [BsonKnownTypes(typeof(ActivityLog), typeof(ErrorLog))]
    public abstract class Log
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class ActivityLog : Log
    {
        public string RouteParameters { get; set; }
        public string RequestType { get; set; }        
    }
        [BsonIgnoreExtraElements]
        [BsonKnownTypes(typeof(WebErrorLog))]
    public class ErrorLog : Log
    {
        public string StackTrace { get; set; }
    }
        [BsonIgnoreExtraElements]
        [BsonDiscriminator("WebErrorLog")]
    public class WebErrorLog : ErrorLog
    {
        public string RouteParameters { get; set; }
        public string RequestType { get; set; }        
    }
