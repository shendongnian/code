    <!-- language: c# -->
    
        public class ResponseError
        {
            public string ErrorCode { get; set; }
            public string FieldName { get; set; }
            public string Message { get; set; }            
        }
    The `ErrorCode` and `Message` of the `ResponseStatus` object will be taken from the first item of the `Errors` list.
