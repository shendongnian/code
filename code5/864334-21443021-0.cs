    public class JsonFile 
    {
        public JsonFile()
        {
            formatting = Formatting.Indented;
        }
        public JsonFile(Formatting formatting)
        {
            this.formatting = formatting;
        }
        private Formatting formatting;
        public T Load<T>(string filename)
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(json);
        }
        public void Save(string filename, object data)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(data, formatting), Encoding.UTF8);
        }
    }
