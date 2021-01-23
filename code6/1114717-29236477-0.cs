                var items = XDocument.Parse(
                File.ReadAllText(
                Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                    "InputData.xml")))
                          .Element("Departments")
                          .Elements("Department")
                          .Select(
                          d => d.Elements("Item").Select(e => new Item
                          {
                            DepartmentName = d.Attribute("Name").Value,
                            DepartmentNames = new Dictionary<string,string>()
                            {
                                { "en-us", d.Attribute("en-us").Value },
                                { "de-de", d.Attribute("de-de").Value}
                            },
                            Name = e.Attribute("Name").Value,
                            Names = new Dictionary<string,string>()
                            {
                                { "en-us", e.Attribute("en-us").Value},
                                { "de-de", e.Attribute("de-de").Value}
                            }
                          })).ToList();
