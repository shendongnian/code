      [Serializable()]
      [System.Xml.Serialization.XmlRoot("Menu")]
      public class Menu
      {
         [XmlArray("MainMenu")]
         [XmlArrayItem("Meal", typeof(string))]
         public string[] MainMenu { get; set; }
      }
      public static void Main(string[] args)
      {
         XmlSerializer serializer = new XmlSerializer(typeof(Menu));
         using(StreamReader reader = new StreamReader("MenuXML.xml"))
         {
            Menu menu = (Menu)serializer.Deserialize(reader);
            reader.Close();
         }
      }
