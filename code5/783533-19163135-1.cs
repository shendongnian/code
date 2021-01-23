    class Program
    {
        static void Main(string[] args)
        {
            var rf = new ReadFile();
            double d;
            float f;
            int i;
            Console.WriteLine(string.Format( "{1}: {0}", rf.readValue(out d), d ));
            Console.WriteLine(string.Format( "{1}: {0}", rf.readValue(out f), f ));
            // note you don't have to explicitly specify the type for T
            // it is inferred
            Console.WriteLine(string.Format( "{1}: {0}", rf.readValue(out i), i ));
            Console.ReadLine();
        }
    }
    public class ReadFile
    {
        // overload for double
        public string readValue(out double val)
        {
            val = 1.23;
            return "double";
        }
        // overload for float
        public string readValue(out float val)
        {
            val = 0.12f;
            return "float";
        }
        // 'catch-all' generic method
        public string readValue<T>(out T val)
        {
            val = default(T);
            return string.Format("Generic method called with type {0}", typeof(T));
        }
    }
