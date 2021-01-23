    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string content = @"<Events>
        <Event>
            <EventID displayName=""Event ID"">1</EventID>
            <EventName displayName=""Event Name"">Some event</EventName>
            <OrgID displayName=""Organization ID"">8</OrgID>
        </Event>
        <Event>
            <EventID displayName=""Event ID"">2</EventID>
            <EventName displayName=""Event Name"">Another Event</EventName>
            <OrgID displayName=""Organization ID"">10</OrgID>
        </Event>
    </Events>";
    
                XDocument doc = XDocument.Load(new System.IO.StringReader(content));
    
                var events = doc.Descendants("Event")
                .Where(p => p.Elements("EventID").First().Value == "1")
                .Where(p => p.Elements("OrgID").First().Value == "8" || p.Elements("OrgID").First().Value == "10");
            }
        }
    }
