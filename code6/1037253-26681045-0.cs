    public static void updatenode(string bankname, string templatemodel,string field,string x,string y)
    {
        XDocument doc = XDocument.Load("newtest.xml");
        XElement  updatenode = doc
                    .Descendants("BankName")
                    .Where(item => item.Attribute("BankName").Value == bankname && item.Attribute("TemplateModel").Value == templatemodel)
                    .Select(XandYPosition => XandYPosition.Descendants("XandYPosition").Descendants());
        updatenode.Where(x => x.Attribute("Name").Value == field).Attribute("X").Value = x;
        updatenode.Where(x => x.Attribute("Name").Value == field).Attribute("Y").Value = y;
        doc.save("newtest.xml");
    }
