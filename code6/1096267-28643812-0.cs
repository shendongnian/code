    class XmlData{
        public string Person;
        public XmlData(){
              Person=null;
        }
    }
    class Program{
         static void Main(){
            var xmlTaplate=new XmlData();//in this step property Person is null    
            var serializer = new XmlSerializer(typeof(xmlTemplate));
            
            using (TextWriter writer = new StreamWriter(@"person.xml"))
            {
                serializer.Serialize(writer, details);
            }
         }
    }
