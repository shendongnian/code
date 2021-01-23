         public class Rootobject
         {
            public string xmlns { get; set; }
            public string text { get; set; }
         }
   
        public static void Main(string[] args) 
        { 
          Rootobject details = new Rootobject();
          details.xmlns = "myNamespace";
          details.text = "Value";
     
          Serialize(details);
       }   
       static public void Serialize(Rootobject details)
       { 
         XmlSerializer serializer = new XmlSerializer(typeof(Rootobject)); 
         using (TextWriter writer = new StreamWriter(@"C:\Xml.xml"))
         {
           serializer.Serialize(writer, details); 
         } 
       }
