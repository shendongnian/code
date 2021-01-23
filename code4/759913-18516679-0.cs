    public class Widget
    {
        // declares a delegate called AddDelegate that takes a param of doubles
        public delegate double AddDelegate(params double[] dbls);
        Dictionary<string, AddDelegate> functions;
        public Widget()
        {
            functions = new Dictionary<string, AddDelegate>();
        }
        public void Add(AddDelegate d)
        {
            functions.Add(d.Method.Name, d);
        }
        public void Run()
        {
            foreach (var kvp in functions)
            {
                // write out the name and result of each function added to our list
                Console.Write(kvp.Key);
                Console.Write(": ");
                Console.Write(kvp.Value(10.0, 10.0, 10.0, 10.0));
            }
        }
    }
    class Program
    {
        static double CalcDouble(params double[] dbls)
        {
            double total = 0.0;
            foreach (double d in dbls)
            {
                total += d;
            }
            return total;
        }
        static void Main(string[] args)
        {
            var w = new Widget();
            w.Add(new Widget.AddDelegate(CalcDouble));
            w.Run();
        }
    }
