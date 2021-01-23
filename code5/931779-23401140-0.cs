    public interface ISample
    {
        IList<string> GetData();
    }
    
    public class Sample1 :ISample
    {
        public IList<string> GetData()
        {
            IList<string> names = new List<string>();
            names.Add("Tom");
            names.Add("Peter");
            return names;
        }
    }
    public class Sample2 : ISample
    {
        public IList<string> GetData()
        {
            IList<string> names = new List<string>();
            names.Add("Human");
            names.Add("Immortal");
            return names;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new CalledClass();
            IList<string> data = c1.GetData(new Sample2());
            foreach (var name in data)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }
    }
