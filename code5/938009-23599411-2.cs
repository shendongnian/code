    expression model = new expression() { term1 = new expression() { operation = " + " } };
    string content = ModelManager<expression>.SaveToString(model);
    /* content =
    {
        "$type": "Test.expression, Test",
        "term1": {
        "$type": "Test.expression, Test",
        "operation": " + "
        }
    }
    */
    var model2 = ModelManager<expression>.LoadFromString(content);
    string content2 = ModelManager<expression>.SaveToString(model2);
    // content == content2 
    public static class ModelManager<T>
    {
        public static T LoadFromString(string content)
        {    
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
