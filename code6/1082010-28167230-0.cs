    foreach (var continent in xml.Descendants(cm + "Continent"))
    {
         var continent = (string)continent.Element(cm + "Name");
         foreach (var country in continent.Elements(cm + "Country"))
         {
             var country = (string)country.Element(cm + "Name");
             foreach (var city in country.Elements(cm + "City"))
             {
                 Location l = new Location();
                 l.Continent = continent;
                 l.Country = country;
                 l.City = (string)city.Element(cm + "Name");
                 context.Locations.Add(l);
                 locationColl.Add(l);
                 foreach (var events in city.Elements(cm + "Event"))
                 {
                     Event e = new Event();
                     eventColl.Add(e);
                     e.Location = l;
                     eventColl[i2].Name = (string)events.Element(cm + "Name");
                     eventColl[i2].Date = (string)events.Element(cm + "Date");
                     context.Events.Add(eventColl[i2]);
                     i2++;
                 }
                 i++;
             }
         }
     }
     context.SaveChanges();
