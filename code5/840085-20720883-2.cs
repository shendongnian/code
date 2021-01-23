    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace App
    {
        public class SchrijfKlanten
        {
            public SchrijfKlanten(Klant klant, string pad)
            {
    
                using (FileStream file = File.Open(pad, FileMode.OpenOrCreate))
                {
                    XmlSerializer xml = new XmlSerializer(klant.GetType()); //THIS LINE
    
                    xml.Serialize(file, klant);
                }
            }
    
            private SchrijfKlanten() { }
    
          
    
            // cut other methods
        }
        [Serializable()]
        //Ensure there is a parameter less constructor in the class klant
        public class Klant
        {
            internal Klant()
            {
            }
               
            public string Name { get; set; }
    
            public static String type { get; set; }
             public static Type IAm { get; set; }
        }
    }
