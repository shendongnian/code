    class Program
    {
        static void Main()
        {
            Requester objectToDeserialize;
            using (Stream stream = File.Open("file.xml", FileMode.Open))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Requester));
                objectToDeserialize = (Requester)deserializer.Deserialize(stream);
            }
            Console.WriteLine(objectToDeserialize.Test);
            Console.WriteLine(objectToDeserialize.LabelType);
            Console.WriteLine(objectToDeserialize.LabelSubtype);
            Console.WriteLine(objectToDeserialize.LabelSize);
            Console.WriteLine(objectToDeserialize.ImageFormat);
            Console.WriteLine(objectToDeserialize.MailpieceShape);
            Console.WriteLine(objectToDeserialize.Services.Open);
            Console.WriteLine(objectToDeserialize.Options.Mail);
            Console.ReadLine();
        }
    }
    [XmlRoot(ElementName = "LabelRequest")]
    public class Requester
    {
        [XmlAttribute]
        public string Test { get; set; }
        [XmlAttribute]
        public string LabelType { get; set; }
        [XmlAttribute]
        public string LabelSubtype { get; set; }
        [XmlAttribute]
        public string LabelSize { get; set; }
        [XmlAttribute]
        public string ImageFormat { get; set; }
        public string MailpieceShape { get; set; }
        public Services Services { get; set; }
        public Options Options { get; set; }
    }
    public class Services
    {
        [XmlAttribute]
        public string Open { get; set; }
    }
    public class Options
    {
        [XmlAttribute]
        public string Mail { get; set; }
    }
