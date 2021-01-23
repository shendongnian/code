     var q1 = from r in dt.Rows.Cast<DataRow>()
     group r by MyGetHashCode(r)
     into g
     from intermidiate in g
     select new { 
       Row = g.First(), 
       Max = g.Max(v => (int.Parse(r[4].ToString())))
     }
     select 
      new {
        Time = Arrange5Min(Convert.ToDateTime(intermidiate[0].ToString())),
    	Host = intermidiate.Row[2].ToString(),
        Agent = intermidiate.Row[1].ToString(),
        Metric = intermidiate.Row[3].ToString(),
        Max = g.Max(v => (int.Parse(r[4].ToString())))
     } 
