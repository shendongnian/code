    class JsonItemWriter
    {
        private JsonTextWriter innerWriter;
        private JsonSerializer serializer;
        public JsonItemWriter(JsonTextWriter innerWriter, JsonSerializer serializer)
        {
            this.innerWriter = innerWriter;
            this.serializer = serializer;
        }
        public void WriteItem(object item)
        {
            if (innerWriter.WriteState == Newtonsoft.Json.WriteState.Start)
            {
                innerWriter.WriteStartArray();
            }
            serializer.Serialize(innerWriter, item);
            innerWriter.Flush();
        }
        public void Close()
        {
            innerWriter.WriteEndArray();
            innerWriter.Close();
        }
    }
