    // I've changed your xml to be consistent. Lowercase name and captial attributes
    string xml = @"<Countries>
                       <country name=""India"">
                           <State name=""Maharashtra"" capital=""Mumbai"" PIN=""400001""/>
                           <State name=""Uttar-Pradesh"" capital=""Lucknow"" PIN=""220001""/>
                       </country>
                       <country name=""Sri-Lanka"">
                           <State name=""Colombo"" capital=""Colombo"" PIN=""123456""/>
                           <State name=""Candy"" capital=""Jafana"" PIN=""654321""/>
                       </country>
                   </Countries>";
    // Load the xml
    XDocument StockDoc = XDocument.Parse(xml);
    // Get states where country is "India"
    IEnumerable<XElement> states = StockDoc.Root.Descendants("country")
                                           .Where(x => (string)x.Attribute("name") == "India")
                                           .Descendants("State");
    // Build a new strongly typed IEnumerable<CountryData> from the xml states.
    // Properties on classes in C# typically do not start with underscores. 
    IEnumerable<CountryData> countryData = states.Select(y => new CountryData
                                                                  {
                                                                      _State = (string)y.Attribute("name").Value,
                                                                      _Capital = (string)y.Attribute("capital").Value,
                                                                      _Pin = (string)y.Attribute("PIN").Value
                                                                  });
