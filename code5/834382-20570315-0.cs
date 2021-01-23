    public static List<XmlData> DeserializeFromXml(string inputFile)
    {
         List<XmlData> mydata = new List<XmlData>();
         XmlSerializer s = new XmlSerializer(typeof(List<XmlData>),new XmlRootAttribute("Asset"));
         //XmlData[] deserializedObject = default(XmlData[]);
         //byte[] byteArray = Encoding.UTF8.GetBytes(inputFile);
         //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
         //MemoryStream stream = new MemoryStream(byteArray);
         using (TextReader txtReader = new StreamReader(inputFile))
         {
            mydata = (List<XmlData>)s.Deserialize(txtReader);
         }
    
         return mydata;
    }
