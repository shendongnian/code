    public class HandleExceptionFilter : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
    		var model = new ApiResponseDto() { Success = false, Error = context.Exception.Message })
    		
    		responseMessage.Content = new JsonContent(model);
    
            context.Response = responseMessage;
        }
    }
    public class JsonContent : HttpContent
    {
    
        private readonly MemoryStream _Stream = new MemoryStream();
        public JsonContent(object value)
        {
    
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jw = new JsonTextWriter(new StreamWriter(_Stream));
            jw.Formatting = Formatting.Indented;
            var serializer = new JsonSerializer();
            serializer.Serialize(jw, value);
            jw.Flush();
            _Stream.Position = 0;
    
        }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return _Stream.CopyToAsync(stream);
        }
    
        protected override bool TryComputeLength(out long length)
        {
            length = _Stream.Length;
            return true;
        }
    }
