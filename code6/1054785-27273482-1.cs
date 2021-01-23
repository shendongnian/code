        var machines = from t in db.Experiments
                       group t by new { Machine = t.Machine } into g
                       select new { Machine = t.Key.Machine };
        foreach (var m in machines)
        {
        var last5Samples = (from t in db.Experiments
                        where t.Machine = m.Machine
                        orderby t.Completed descending
                        select t.Sample).ToList().Distinct().Take(5);
    
        var expsForLast5Samples = from t in db.Experiments
							  where last5Samples.Contains(t.Sample)
							  select t;
        }
