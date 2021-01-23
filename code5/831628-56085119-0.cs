using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Http.Helper.Extensions
{
    public class JsonHttpContentSerializer : HttpContent
    {
        private object Value { get; set; }
        public JsonHttpContentSerializer(Object value)
        {
            this.Value = value;
        }
       
        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            using (var streamWriter = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            {
                using (var jsonTextWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
                {
                    var jsonSerializer = new JsonSerializer();
                    jsonSerializer.Serialize(jsonTextWriter, Value);
                    jsonTextWriter.Flush();
                }
            }
        }
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
and you would use like it 
var jsonSerializeContent = new JsonHttpContentSerializer(someContent);
httpRequestMessage.Content = jsonSerializeContent;
