    MyApp ma = MyApp.Deserialize(strXml);
    public static MyApp Deserialize(string xml) {
        System.IO.StringReader stringReader = null;
        try {
          stringReader = new System.IO.StringReader(xml);
          var xmlSerializer = new XmlSerializer(MyApp.GetType(), new XmlRootAttribute("car");
            var myApp = xmlSerializer.Deserialize(stringReader) as MyApp;
            return myApp;
          } finally {
            if ((stringReader != null)) {
              stringReader.Dispose();
            }
          }
        }
