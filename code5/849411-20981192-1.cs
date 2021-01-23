    public class Model {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShouldSerializeName() {
            return Name != null;
        }
    }
    class Program {
        static void Main(string[] args) {
            var t1 = new Model {
                Name = "apw8u3rdmapw3urdm",
                Id = 298384
            };
            var t2 = new Model {
                Id = 234235
            };
            Test(t1);
            Test(t2);
        }
        static void Test(Model model) {
            Console.WriteLine("JSon from .Net: {0}", ToJson(model));
            Console.WriteLine("JSon from JSon.Net: {0}", ToDotNetJson(model));
        }
        static string ToJson(Model model) {
            var s = new JavaScriptSerializer();
            return s.Serialize(model);
        }
        static string ToDotNetJson(Model model) {
            return JsonConvert.SerializeObject(model);
        }
    }
