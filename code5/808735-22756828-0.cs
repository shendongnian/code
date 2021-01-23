    config.Formatters.Add(new WrappedJsonMediaTypeFormatter());
    public class WrappedJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
            public WrappedJsonMediaTypeFormatter() 
            {
                base.SerializerSettings.Culture = new System.Globalization.CultureInfo("en-GB");
                base.SerializerSettings.DateFormatString = "dd/MM/yyyy";
            }
        
            public override System.Threading.Tasks.Task WriteToStreamAsync(System.Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
            {
                var obj = value;
                if (type.IsPrimitive || Object.ReferenceEquals(type, typeof(string)))
                    obj = new { data = value };
                if (Object.ReferenceEquals(value, null))
                    obj = new { };
                return base.WriteToStreamAsync(type, obj, writeStream, content, transportContext);
            }
        }
