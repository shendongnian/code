    //http://james.newtonking.com/archive/2008/10/16/asp-net-mvc-and-json-net.aspx
    public class JsonNetResult : ActionResult
    {
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public object Data { get; set; }
        public JsonSerializerSettings SerializerSettings { get; set; }
        public Formatting Formatting { get; set; }
        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings
                {
                    //http://odetocode.com/blogs/scott/archive/2013/03/25/asp-net-webapi-tip-3-camelcasing-json.aspx
                    #if DEBUG
                    Formatting = Formatting.Indented, //Makes the outputted Json for structures for easier reading by a human, only needed in debug
                    #endif
                    ContractResolver = new CamelCasePropertyNamesContractResolver() //Makes the default for properties outputted by Json to use camelCaps
                };
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType)
                                       ? ContentType
                                       : "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) {Formatting = Formatting};
                JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }
    public static class JsonNetExtenionMethods
    {
        public static ActionResult JsonNet(this Controller controller, object data)
        {
            return new JsonNetResult() {Data = data};
        }
        public static ActionResult JsonNet(this Controller controller, object data, string contentType)
        {
            return new JsonNetResult() { Data = data, ContentType = contentType };
        }
        public static ActionResult JsonNet(this Controller controller, object data, Formatting formatting)
        {
            return new JsonNetResult() {Data = data, Formatting = formatting};
        }
    }
