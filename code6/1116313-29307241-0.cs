            XElement dataSet1Tree = XElement.Parse(xml);
            var dataSet1List = dataSet1Tree.Elements().Select(
            root => new
            {
                Name = (string)root.Element("Name"),
                StreetAddress = (string)root.Element("StreetAddress"),
                Service = root.Elements("Service")
                    .Select(service => new
                    {
                        Type = (string)service.Element("Type"),
                        PhoneNumber = (string)service.Element("PhoneNumber"),
                        OpenWeekDay = (string)service.Element("Openweekday")
                    })
            }).SelectMany(root => root.Service, (root, service) => new
            {
                Name = root.Name, 
                StreetAddress = root.StreetAddress , 
                Type = service.Type, 
                PhoneNumber = service.PhoneNumber,
                OpenWeekDay = service.OpenWeekDay
            }).Aggregate("",(sb,s)=> sb +=string.Format("{0},{1},{2},{3},{4}",
                                                        s.Name,
														s.StreetAddress,
														s.Type,
														s.PhoneNumber, 
														s.OpenWeekDay)+"\r\n");
    Console.WriteLine(dataSet1List);
