    class Program
    {
        static void Main(string[] args)
        {
            var classType = typeof (Class1);
            foreach (var prop in classType.GetProperties().Where(p => p.CanWrite))
            {
                Console.WriteLine(prop.Name);
            }
            foreach (var field in classType.GetFields())
            {
                Console.WriteLine(field.Name);
            }
        }
    }
    public class Class1
    {
        public string ABC { get; set; }
        public string DEF { get; set; }
        public string GHI { get; set; }
        public string JLK { get; set; }
        public string CantWrite { get { return ""; } }
        public string Field = "";
    }
