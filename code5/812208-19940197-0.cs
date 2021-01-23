    public class Base
    {
        public string Name { get; set; }
        public List<int> Values { get; set; }
    }
    [Serializable]
    public class Derived : Base 
    {
        public double X { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Derived() { X = 3.1415, Values = new List<int> { 3, 1, 4, 1, 5 }, Name = "Pi" };
            var stream = new MemoryStream();
            new XmlSerializer(typeof(Derived)).Serialize(stream, d);
            string result = Encoding.UTF8.GetString(stream.GetBuffer());
        }
    }
