    using System;
    using System.Data;
    using System.Linq;
    
    ...
    var results = from row in ds.Tables[0].AsEnumerable()
        group row by ((DateTime) row["TheDate"]).TimeOfDay
        into g
        select new
                {
                    Time = g.Key,
                    AvgValue = g.Average(x => (int) x["TheValue"])
                };
