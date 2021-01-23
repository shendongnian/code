    /// <summary>
    /// Sends HTTP content as JSON
    /// </summary>
    /// <remarks>Thanks to Darrel Miller</remarks>
    /// <seealso cref="http://www.bizcoder.com/returning-raw-json-content-from-asp-net-web-api"/>
    public class JsonContent : HttpContent
    {
        private readonly JToken jToken;
        public JsonContent(String json) { jToken = JObject.Parse(json); }
        public JsonContent(JToken value)
        {
            jToken = value;
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var jw = new JsonTextWriter(new StreamWriter(stream))
            {
                Formatting = Formatting.Indented
            };
            jToken.WriteTo(jw);
            jw.Flush();
            return Task.FromResult<object>(null);
        }
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
