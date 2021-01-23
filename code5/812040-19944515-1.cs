    public List<Category> GetCategoryList(string xmlFile)
    {
        XDocument doc = XDocument.Load(xmlFile);
        List<Category> categories = (from xElem in doc.Descendants("category")
                                        select new Category
                                        {
                                            name = xElem.Attribute("name").Value,
                                            first = new Answer(decimal.Parse(xElem.Element("first").Attribute("points").Value),
                                                                xElem.Element("first").Attribute("answer").Value,
                                                                xElem.Element("first").Value),
                                            second = new Answer(decimal.Parse(xElem.Element("second").Attribute("points").Value),
                                                                xElem.Element("second").Attribute("answer").Value,
                                                                xElem.Element("second").Value),
                                            third = new Answer(decimal.Parse(xElem.Element("third").Attribute("points").Value),
                                                                xElem.Element("third").Attribute("answer").Value,
                                                                xElem.Element("third").Value),
                                            fourth = new Answer(decimal.Parse(xElem.Element("fourth").Attribute("points").Value),
                                                                xElem.Element("fourth").Attribute("answer").Value,
                                                                xElem.Element("fourth").Value),
    
                                            fifth = new Answer(decimal.Parse(xElem.Element("fifth").Attribute("points").Value),
                                                                xElem.Element("fifth").Attribute("answer").Value,
                                                                xElem.Element("fifth").Value),
                                        }).ToList();
        return categories;
    }
