    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                Dictionary<string, SampleTree> tree = new Dictionary<string, SampleTree>();
                var a = new SampleTree
                {
                    Value = new SampleClass
                    {
                        A = "abc",
                        B = 1,
                        C = true
                    },
                    Parent = null
                };
    
                var treeChild = new SampleTree
                {
                    Value = new SampleClass
                    {
                        A = "def",
                        B = 2,
                        C = false
                    },
                    Parent = a
                };
    
                tree.Add("parent", a);
                tree.Add("child", treeChild);
    
                var serializerSettings = new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.All,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    Formatting = Formatting.Indented
                };
    
                var serialized = JsonConvert.SerializeObject(tree, serializerSettings);
    
                var deserialized = JsonConvert.DeserializeObject<Dictionary<string, SampleTree>>(serialized, serializerSettings);
    
                var d = deserialized;
            }
        }
    
        [JsonObject(IsReference = true, ItemReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public class SampleTree
        {
            [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
            public SampleClass Value { get; set; }
    
            [JsonProperty(IsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
            public SampleTree Parent { get; set; }
        }
    
        [JsonObject(IsReference = true)]
        public class SampleClass
        {
            public string A { get; set; }
    
            public int B { get; set; }
    
            public bool C { get; set; }
        }
    
    }
