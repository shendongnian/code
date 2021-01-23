    public List<string> GetList()
    {
        List<string> result = new List<string>();
        XDocument d = XDocument.Load(@"c:\text.xml");
        foreach (var name in d.Root.DescendantNodes().OfType<XElement>().Select(x => x.Name).Distinct())
        {
            XElement xe = (from c in d.Descendants(name.ToString()) select c).FirstOrDefault();
            string fullName = getFullName(xe, d, "");
            string[] sarr = fullName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(sarr);
            string result = string.Join(".", sarr);
            result.Add(result);
        }
    }
    private string getFullName(XElement elem, XDocument doc, string prevName)
    {
        if (elem.Parent == null)
        {
            prevName += "." + elem.Name.ToString();
        }
        else
        {
            prevName += "." + getFullName(elem.Parent, doc, elem.Name.ToString());
        }
        return prevName;
    }
