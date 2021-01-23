       [XmlRoot(ElementName = "Players")] 
        public class Players : System.Collections.Generic.List<Player> {
            public Players() { }
        }
     
       public class Player{
       public string Name { get; set; }
           public string Team { get; set; } 
           public string Position { get; set; }
           public Player(string name, string position, string team) {
               this.Name = name;
               this.Position = position;
               this.Team = team;
           }
           public Player() { }
       }
     
    
        [System.Runtime.InteropServices.GuidAttribute("D36900FE-8902-4ED8-B961-DE5B3F3273AC")]
        class Program
        {
            static void Main(string[] args)
            {
                Players players= new Players();
                players.Add(new Player("C.Ronaldo", "Man Utd", "Midfielder"));
                XmlSerializer ser = new XmlSerializer(typeof(Players));
                var writer = new System.IO.StreamWriter(@"C:\myxml.xml", false);
                ser.Serialize(writer, players);
                writer.Flush();
                writer.Close();            
                var myXslTrans = new XslCompiledTransform();
                myXslTrans.Load(@"C:\CSV.xslt", null, null );            
                myXslTrans.Transform(@"file://C:/myxml.xml", @"C:\converted.csv"); 
            }
        }
    }
