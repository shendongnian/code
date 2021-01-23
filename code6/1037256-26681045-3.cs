    public static void updatenode(string bankname, string templatemodel,string field,string X,string Y)
    {
        XDocument xDoc = XDocument.Load("../../newTest.xml");
        IEnumerable<XElement> updatenode = xDoc.Descendants("BankName")
                                               .Where(x => x.Attribute("BankName").Value == bankname && x.Attribute("TemplateModel").Value == templatemodel)
                                               .Select(x => x.Element("XandYPosition").Elements("column")).FirstOrDefault();
        updatenode.Where(x => x.Attribute("Name").Value == field).FirstOrDefault().Attribute("X").Value = X;
        updatenode.Where(x => x.Attribute("Name").Value == field).FirstOrDefault().Attribute("Y").Value = Y;
        xDoc.Save("../../newTest.xml");
    }
