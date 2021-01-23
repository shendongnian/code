    static void Main(string[] args)
    {
        string result = GetXmlPlanForQuery("select TOTAL_SALES from clients where ACTIVE = 0;");
        XmlSerializer ser = new XmlSerializer(typeof(ShowPlanXML));
        var plan = (ShowPlanXML)ser.Deserialize(new StringReader(result));
        var missingIndexes =
            plan.BatchSequence.SelectMany(x => x)
                .SelectMany(x => x.Items)
                .OfType<StmtSimpleType>()
                .Select(x => x.QueryPlan)
                .Where(x => x.MissingIndexes.Any());
        foreach (var queryPlan in missingIndexes)
        {
            //This will hit for each statement in the query that was missing a index, check queryPlan.MissingIndexes to see the indexes that are missing.
            Debugger.Break();
        }
            
        Console.WriteLine("Done");
        Console.ReadLine();
    }
