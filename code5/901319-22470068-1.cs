    JObject rss =
             resultSet.Cast<XDocument>().Select(p => new JObject(p.Product,
                        new JProperty("MonthYearShortName", p.MonthYearShortName),
                        new JProperty("Actual", p.Actual),
                        new JProperty("Forecast", p.Forecast),
                        new JProperty("Target", p.Target)));
    
                Console.WriteLine(rss.ToString());
