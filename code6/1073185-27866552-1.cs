    class Program
    {
        static void Main(string[] args)
        {
            RootObject imp = new RootObject
            {
                userdata = new UserData
                {
                    name = "name",
                    type = "type",
                    company_name = "company_name"
                },
                attributes = new List<Attribute>
                {
                    new Attribute
                    {
                        firstval = "0",
                        name = "at 0",
                        opposite_name = "oppname 0"
                    },
                    new Attribute
                    {
                        firstval = "1",
                        name = "at 1",
                        opposite_name = "oppname 1"
                    },
                    new Attribute
                    {
                        firstval = "2",
                        name = "at 2",
                        opposite_name = "oppname 2"
                    }
                }
            };
            var json = JsonConvert.SerializeObject(imp, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
    public class RootObject
    {
        public UserData userdata { get; set; }
        public object f_item { get; set; }
        public object o_item { get; set; }
        [JsonConverter(typeof(ListToObjectConverter))]
        public List<Attribute> attributes { get; set; }
        public object eos { get; set; }
    }
    public class UserData
    {
        public string name { get; set; }
        public string type { get; set; }
        public string company_name { get; set; }
    }
    public class Attribute
    {
        public string firstval { get; set; }
        public string name { get; set; }
        public string opposite_name { get; set; }
    }
