            using (MyContext c = new MyContext())
            {
                c.AttributeTypes.Add(new AttributeType { AttributeTypeName = "Fish", AttributeTypeId = 1 });
                c.AttributeTypes.Add(new AttributeType { AttributeTypeName = "Face", AttributeTypeId = 2 });
                c.SaveChanges();
            }
            using (MyContext c = new MyContext())
            {
                Dictionary<int, AttributeType> dictionary = new Dictionary<int, AttributeType>();
                foreach (var t in c.AttributeTypes)
                {
                    dictionary[t.AttributeTypeId] = t;
                }
                Location l1 = new Location(1, "Location1") { AttributeTypes = { dictionary[1], dictionary[2] } };
                Location l2 = new Location(2, "Location2") { AttributeTypes = { dictionary[1] } };
                // Because the LocationType is already attached to the context, it doesn't get re-added.
                c.Locations.Add(l1);
                c.Locations.Add(l2);
                c.SaveChanges();
            }
