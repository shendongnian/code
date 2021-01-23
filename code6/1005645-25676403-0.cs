    [Serializable()]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public class Package
    {
        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public string Id { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute("version")]
        public string Version { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("packages")]
    public class PackageCollection
    {
        [System.Xml.Serialization.XmlElementAttribute("package")]
        public Package[] Packages { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var path = @"C:\packages.config";
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(PackageCollection));
            StreamReader reader = new StreamReader(path);
            var packages2 = (PackageCollection)serializer.Deserialize(reader);
            foreach (Package pkg in packages2.Packages)
            {
                Console.WriteLine("ID: " + pkg.Id);
                Console.WriteLine("Version: " + pkg.Version);
                Console.WriteLine();
            }
            reader.Close();
        }
    }
