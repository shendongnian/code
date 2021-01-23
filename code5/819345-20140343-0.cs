    namespace XmlGen {
    public class Program {
        private static void Main( string[] args ) {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlItem));
            TextWriter writer = new StreamWriter(@"C:\Users\hasch\Downloads\test.xml");
            XmlItem item = new XmlItem();
            serializer.Serialize(writer,item);
        }
    }
    public class XmlItem {
        public KilometerUpload KilometerUpload;
        public KilometerRegistration KilometerRegistration;
        
        public XmlItem() {
            KilometerUpload = new KilometerUpload();
            KilometerRegistration = new KilometerRegistration();
        }
    }
    public class KilometerUpload {
    }
    public class KilometerRegistration {
        public string ChassisNumber { get; set; }
        public string KilometerStatus { get; set; }
        public string TypeOfData { get; set; }
        public KilometerRegistration() {
            ChassisNumber = "WVWZZZ3CZ7E201402";
            KilometerStatus = "78000";
            TypeOfData = "120";
        }}}
