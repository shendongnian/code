    class Program
    {
        static void Main(string[] args)
        {
            var rf = new ReadFile();
            double d = 1.23;
            float f = 0.12f;
            int i = 1;
            Console.WriteLine(rf.readValue(d));
            Console.WriteLine(rf.readValue(f));
            // note you don't have to explicitly specify the type for T
            // it is inferred
            Console.WriteLine(rf.readValue(i));
            Console.ReadLine();
        }
    }
    public class ReadFile
    {
        // overload for double
        public string readValue(double val)
        {
            return "double";
        }
        // overload for float
        public string readValue(float val)
        {
            return "float";
        }
        // 'catch-all' generic method
        public string readValue<T>(T val)
        {
            return string.Format("Generic method called with type {0}", typeof(T));
        }
    }
