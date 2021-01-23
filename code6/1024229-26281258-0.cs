    public class JsonStreamingResult : ActionResult
    {
        private IEnumerable itemsToSerialize;
        public JsonStreamingResult(IEnumerable itemsToSerialize)
        {
            this.itemsToSerialize = itemsToSerialize;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(response.OutputStream))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartArray();
                foreach (object item in itemsToSerialize)
                {
                    JObject obj = JObject.FromObject(item, serializer);
                    obj.WriteTo(writer);
                    writer.Flush();
                }
                writer.WriteEndArray();
            }
        }
    }
