    List<ExpandoObject> flattenSummary3 = new List<ExpandoObject>();
    foreach ( var s in a.Summaries)
    {
    	flattenSummary3.Add(s.ToExpando());
    }
