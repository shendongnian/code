    public enum Status
    {
        OK = 1,
        ERROR = -1,
    }
    public class ResponseDTO
    {
        public static ResponseDTO CreateDynamicResponse(object content)
        {
            return new ResponseDTO {Status = Status.OK, Content = content};
        }
        public static ResponseDTO CreateDynamicResponseFromException(RovlerBaseException ex)
        {
            return new ResponseDTO
            {
                Status = Status.ERROR,
                Message = ex.Message,
            };
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] 
        public Status Status;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Content { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
