    var eventList=doc.Elements("Event")
                     .Select(x=>new 
                      {
                          EventId=int.Parse(x.Element("EventId").Value),
                          EventName=x.Element("EventName").Value,
                          OrgID=int.Parse(x.Element("OrgID").Value)
                      });
