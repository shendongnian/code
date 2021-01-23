    [DataContract]
    public class Mydata
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Mydata> myData = new List<Mydata>();
            myData.Add(new Mydata() { Id = 1, Name = "Object 1" });
            myData.Add(new Mydata() { Id = 2, Name = "Object 2" });
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + typeof(Mydata).ToString() + ".xml";
            Save<Mydata>(myData, path);
            List<Mydata> myNewData = Load<Mydata>(path);
            Console.WriteLine(myNewData.Count);
            Console.ReadLine();
        }
        public static List<T> Load<T>(string filename) where T : class
        {
            var serializer = new DataContractSerializer(typeof(List<T>));
            
            if (!System.IO.File.Exists(filename))
            {
                return new List<T>();
            }
            else
            {
                using (var s = new System.IO.FileStream(filename, System.IO.FileMode.Open))
                {
                    return serializer.ReadObject(s) as List<T>;
                }
            }
        }
        public static void Save<T>(List<T> list, string filename)
        {
            var serializer = new DataContractSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs))
                {
                    serializer.WriteObject(writer, list);
                }
            }
        }
    }
