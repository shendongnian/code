    class Program
    {
        static void Main(string[] args)
        {
            var holder = new Holder();
            holder.CurrentPart = new Part() { Name = "Inital Part" };
            Console.WriteLine(holder.CurrentPart.Name);
            TestRef(ref holder.CurrentPart);
            Console.WriteLine(holder.CurrentPart.Name);
            Console.ReadKey();
        }
        public static void TestRef(ref Part part)
        {
            part = new Part() { Name = "changed" };
        }
    }
    public class Part
    {
        public string Name;
    }
    public class Holder
    {
        public Part CurrentPart;
    }
