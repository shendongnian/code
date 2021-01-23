    public class HttpException
    {
        public string Text { get; set; }
        public string Message { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string InnerExceptionInnerExceptionMessage { get; set; }
        public static string CreateJsonString(string Text, string Message, 
                                              string InnerExceptionMessage, 
                                              string InnerExceptionInnerExceptionMessage) {
            return JSON.ToJSONString(new HttpException() {
                                         Text = "City not created",
                                         Message = ex.Message,
                                         InnerExceptionMessage = ex.InnerException.Message,
                                         InnerExceptionInnerExceptionMessage = 
                                         ex.InnerException.InnerException.Message});
       }
    }
