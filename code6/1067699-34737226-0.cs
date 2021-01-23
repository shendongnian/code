    class Program
    {
        static void Main(string[] args)
        {
            var swc = new SomethingWithCode { 
                          JustSomething = "hello", 
                          FuncDeclaration = "function() { alert('here'); }" 
            };
            
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new FunctionJsonConverter());
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            using (var sw = new System.IO.StringWriter())
            {
                using (var writer = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, swc);
                }
                Console.Write(sw.ToString());
            }
        }
    }
    
    class SomethingWithCode
    {
        public string JustSomething { get; set; }
        public JavaScriptFunctionDeclaration FuncDeclaration { get; set; }
    }
    class JavaScriptFunctionDeclaration
    {
        private string Code;
        public static implicit operator JavaScriptFunctionDeclaration(string value)
        {
            return new JavaScriptFunctionDeclaration { Code = value };
        }
        public override string ToString()
        {
            return this.Code;
        }
    }
    class FunctionJsonConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(JavaScriptFunctionDeclaration);
        }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }
