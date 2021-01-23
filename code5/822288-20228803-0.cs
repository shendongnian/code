    var query = from r in dt.Rows.Cast<DataRow>()
                let ts = Convert.ToDateTime(r[0].ToString())
                group r by ts.Ticks / ticksInFiveMinutes
                into g
                select new
                {
                    ts = g.Key,
                    agentName = g.Select(r => r[1].ToString()),
                    Sum = g.Sum(r => (int.Parse(r[4].ToString()))),
                    Average = g.Average(r => (int.Parse(r[4].ToString()))),
                    Max = g.Max(r => (int.Parse(r[4].ToString())))
                };
