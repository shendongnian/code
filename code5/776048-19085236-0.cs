    using System;
    using System.IO;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    
    namespace EMP.WebServices.api.Formatters
    {
        public class CustomXmlFormatter : MediaTypeFormatter
        {
            public CustomXmlFormatter()
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
            }
    
            public override bool CanReadType(Type type)
            {
                if (type == (Type)null)
                    throw new ArgumentNullException("type");
    
                return true;
            }
    
            public override bool CanWriteType(Type type)
            {
                return true;
            }
    
            public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
            {
                return Task.Factory.StartNew(() =>
                    {
                            var json = JsonConvert.SerializeObject(value);
    
                            var xml = JsonConvert.DeserializeXmlNode("{\"Root\":" + json + "}", "");
    
                            xml.Save(writeStream);
                    });
            }
        }
    }
