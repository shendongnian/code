      public static List<XmlData> DeserializeFromXml(string inputFile)
        {
            List<XmlData> mydata = new List<XmlData>();
            XmlSerializer s = new XmlSerializer(typeof(List<XmlData>), new XmlRootAttribute("Asset"));
            //XmlData[] deserializedObject = default(XmlData[]);
           // byte[] byteArray = Encoding.UTF8.GetBytes(inputFile);
         //   byte[] byteArray = Encoding.ASCII.GetBytes(inputfile);
           // MemoryStream stream = new MemoryStream(byteArray);
            
            Stream test = TitleContainer.OpenStream("pets.xml");
            using (TextReader txtReader = new StreamReader(test))
            {
                mydata = (List<XmlData>)s.Deserialize(txtReader);
            }
    
            return mydata;
        }
