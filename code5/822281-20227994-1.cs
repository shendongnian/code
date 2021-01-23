     var q1 = from r in dt.Rows.Cast<DataRow>()
     group r by MyGetHashCode(r)
     into g
     select new {
        Host = g.First()[2].ToString(),
        Agent = g.First()[1].ToString(),
        Metric = g.First()[3].ToString(),
        Max = g.Max(v => (int.Parse(r[4].ToString())))
     }
