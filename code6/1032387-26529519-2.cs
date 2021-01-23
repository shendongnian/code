    [XmlRoot(Namespace = "http://www.xx.com/zz/Domain")]
    public class RootA
    {
       public int element1;
       public int element2;
    }
    [XmlType(Namespace = "http://www.xx.com/zz/Domain")]
    public class TypeA
    {
        public int element1;
        public int element2;
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Serialize<TypeA>();
            Serialize<RootA>();
            Console.ReadLine();
        }
        public static void Serialize<T>() where T : new() 
        {
            Console.WriteLine();
            Console.WriteLine();
            var serializable = new T();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(serializable.GetType());
            Console.WriteLine(serializable.GetType().Name);
            x.Serialize(Console.Out, serializable);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
