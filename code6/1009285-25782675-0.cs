    public class Program
    {
        private string name;
        private string id;
        private Dictionary<string, int> mapper = new Dictionary<string, int>();
        private String[] array= null;
        public Program()
        {
            mapper.Add("name", 1);
            mapper.Add("id", 2);
        }
        public string Name
        {
            get { return array[mapper["name"]]; }
        }
        public string Id
        {
            get { return array[mapper["id"]]; }
        }
        private void Func()
        {
            array = new[] { name, id };
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = "some string";
            }
        }
        public static void Main(string[] args)
        {
            var p = new Program();
            p.Func();
            Console.WriteLine(p.name); // prints null
        }
    }
