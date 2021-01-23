    namespace consoleApp {  
     
        [XmlRoot()]  
        public class EventInput {  
     
            private string group;  
     
            public string Group {  
                get { return group; }  
                set { group = value; }  
            }  
     
            private Event[] events;  
     
            public Event[] Events {  
                get { return events; }  
                set { events = value; }  
            }          
        }  
     
        public class Event {  
            private int id;  
     
            [XmlAttribute]  
            public int Id {  
                get { return id; }  
                set { id = value; }  
            }  
        }  
          
     
          
        class Program {  
     
            public static void Main() {  
              
                string xml = @"  
                    <EventInput> 
                        <Group>12345</Group> 
                        <Events> 
                            <Event Id=""100"" /> 
                            <Event Id=""101"" /> 
                            <Event Id=""102"" /> 
                            <Event Id=""103"" /> 
                            <Event Id=""104"" /> 
                            </Events> 
                    </EventInput>";  
     
                XmlSerializer serializer = new XmlSerializer(typeof(EventInput));  
                EventInput ei = (EventInput)serializer.Deserialize(new StringReader(xml));  
     
                Console.WriteLine(ei.Group);  
                foreach(Event e in ei.Events) {  
                    Console.WriteLine(e.Id);  
                }  
     
                Console.WriteLine("\n=============================\n");  
     
                ei = new EventInput() {  
                    Group = "1111",  
                    Events = new Event[] {   
                        new Event() { Id = 3},   
                        new Event() { Id = 7},   
                        new Event() { Id = 10}}  
                };  
     
                serializer.Serialize(Console.Out, ei);  
            }  
        }  
    }
