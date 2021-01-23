    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<root><ordinal>1</ordinal><postal>02345</postal></root>";
            XmlSerializer xs = new XmlSerializer(typeof(Intermediary));
            using (TextReader reader = new StringReader(xml))
            {
                Intermediary obj = (Intermediary)xs.Deserialize(reader);
                string json = JsonConvert.SerializeObject(obj , Formatting.Indented);
                Console.WriteLine(json);
            }
        }
    }
    [XmlRoot("root")]
    public class Intermediary
    {
        public int ordinal { get; set; }
        public string postal { get; set; }
    }
