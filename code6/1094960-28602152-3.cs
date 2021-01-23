    args = new[] { "dbo.Table1", "dbo.Table3" };
    var test = (from elt in TableSettings.Descendants("Table")
                where args.Contains(elt.Attribute("name").Value)
                select elt).ToList();
    Debug.Assert(test.Count==2);
