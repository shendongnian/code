    public class JsonWithoutNullPropertiesResult : ActionResult
    {
        private object Data { get; set; }
        public JsonWithoutNullPropertiesResult(object data)
        {
            Data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/x-javascript";
            response.ContentEncoding = Encoding.UTF8;
            if (Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new[] { new NullPropertiesConverter() });
                string ser = serializer.Serialize(Data);
                response.Write(ser);
            }
        }
    }
    public class NullPropertiesConverter : JavaScriptConverter
    {
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var toSerialize = new Dictionary<string, object>();
            foreach (var prop in obj.GetType()
                                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                    .Select(p => new
                                    {
                                        Name = p.Name,
                                        Value = p.GetValue(obj)
                                    })
                                    .Where(p => p.Value != null))
            {
                toSerialize.Add(prop.Name, prop.Value);
            }
            return toSerialize;
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return GetType().Assembly.GetTypes(); }
        }
    }
