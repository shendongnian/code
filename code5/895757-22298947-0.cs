    var defaultValues = new List<JsonChartModel> {
       new JsonChartModel{Name = "Today", Value = 0},
       new JsonChartModel{Name = "Last Week", Value = 0}
    };
    
    var result = <YourQuery>.ToList().Union(defaultValues)
                 .GroupBy(m => m.Name)
                 .Select(g => new JsonChartModel) {
                    Name = g.Key,
                    Value = g.Max(x => x.Value)
                 });
