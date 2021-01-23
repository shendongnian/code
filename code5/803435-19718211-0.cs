    class Program
    {
        static void Main(string[] args)
        {
            List<Container> list = new List<Container>
            {
                new Container
                {
                    Cname = "Will serialize Sample because it has a name",
                    Sample = new Sample1 { name = "sample 1" }
                },
                new Container
                {
                    Cname = "Will serialize Sample because it has a non-zero Id",
                    Sample = new Sample1 { Id = 2 }
                },
                new Container
                {
                    Cname = "Will serialize Sample because it has a name and an Id",
                    Sample = new Sample1 { name = "sample 3", Id = 3 }
                },
                new Container
                {
                    Cname = "Will not serialize Sample because it has default values",
                    Sample = new Sample1()
                },
                new Container
                {
                    Cname = "Will not serialize Sample because it is null",
                    Sample = null
                }
            };
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
    public class Sample1
    {
        public String name { get; set; }
        public int Id { get; set; }
    }
    public class Container
    {
        public String Cname { get; set; }
        public Sample1 Sample { get; set; }
        public bool ShouldSerializeSample()
        {
            return (Sample != null && (Sample.Id != 0 || Sample.name != null));
        }
    }
