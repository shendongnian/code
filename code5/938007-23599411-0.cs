    expression model;    
    string content = ModelManager<expression>.SaveToString(model);
    var model2 = ModelManager<expression>.LoadFromString(content);
    public static class ModelManager<T>
    {
        public static T LoadFromString(string content)
        {
            var jsonSerializer = GetSerializer();
    
            using (var sr = new StringReader(content))
            using (var jr = new JsonTextReader(sr))
                return GetSerializer().Deserialize<T>(jr);
        }
        public static string SaveToString(T model)
        {
            StringBuilder sb = new StringBuilder(512);
    
            using (var sw = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture))
            using (var jtw = new JsonTextWriter(sw))
                GetSerializer().Serialize(jtw, model);
    
            return sb.ToString();
        }
            
        private static Newtonsoft.Json.JsonSerializer GetSerializer()
        {
            return new Newtonsoft.Json.JsonSerializer()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                Formatting = Formatting.Indented,
                MaxDepth = null,
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            };
        }
    }
