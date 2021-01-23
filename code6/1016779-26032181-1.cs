        List<dynamic> summaries = new List<dynamic>();
        foreach (var s in a.Summaries)
        {
            summaries.Add(s.DynamicFields.ToExpando());
        }
