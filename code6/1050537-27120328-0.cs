    var result = XDocument.Load(@"Path\Data.xml").Root.Descendants("TestCase")
                           .Select(x => new TestCase 
                           {
                               StoryName = x.Element("StoryName").Value,
                               ScenarioName = x.Element("ScenarioName").Value,
                               TestCaseName = x.Element("TestCaseName").Value,
                               ResponseCode = Convert.ToInt32(x.Element("ResponseCode").Value),
                               userDetails = x.Descendants("UserDetails")
                                              .Select(z => new UserDetail 
                                                { 
                                                     DateOfBirth = !String.IsNullOrEmpty(z.Element("DateOfBirth").Value) ?
                                                                   Convert.ToDateTime(z.Element("DateOfBirth").Value) : DateTime.MinValue }).ToList()
                                                }).ToList();
