            var doc = XDocument.Parse(xml);
            var query = from department in doc.Element("Departments").Elements("Department")
                        from item in department.Elements("Item")
                        select new Item
                        {
                            DepartmentName = department.Attribute("Name").Value,
                            DepartmentNames = department.Attributes().Where(a => a.Name != "Name").ToDictionary(a => a.Name.LocalName, a => a.Value),
                            Name = item.Attribute("Name").Value,
                            Names = item.Attributes().Where(a => a.Name != "Name").ToDictionary(a => a.Name.LocalName, a => a.Value),
                        };
            var items = query.ToList();
