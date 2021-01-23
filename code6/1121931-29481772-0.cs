    public static void Main(params string[] args)
    {
        // test.xml contains OPs example xml.
        var xDoc = XDocument.Load(@"c:\temp\test.xml");
        // this will return an anonymous object for each "ReturnData" node.
        var counts = xDoc.Descendants("ReturnData").Select((e, ndx) => new
        {
            // although xml does not have specified order this will generally
            // work when tracing back to the source.
            Index = ndx,
            // the expected number of child nodes.
            ExpectedCount = e.Attribute("documentCnt") != null ? int.Parse(e.Attribute("documentCnt").Value) : 0,
            // the actual child nodes.
            ActualCount = e.DescendantNodes().Count()
        });
        // now we can select the mismatches
        var mismatches = counts.Where(c => c.ExpectedCount != c.ActualCount).ToList();
        // and the others must therefore be the matches.
        var matches = counts.Except(mismatches).ToList();
        // we expect 3 matches and 0 mismatches for the sample xml.
        Console.WriteLine("{0} matches, {1} mismatches", matches.Count, mismatches.Count);
        Console.ReadLine();
    }
