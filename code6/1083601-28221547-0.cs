    var newResults = days.Select(day =>
        {
            if (lookup.ContainsKey(day))
            {
                return lookup[day];
            }
            else
            {
                return new MetricsResult
                    {
                        Day = day
                    };  
            }
        }).ToList();
