    public Dictionary<string,  SpecFlowData> GetData(Table table)
    {
        var data = table.CreateSet<SpecFlowData>().ToList();
        var result =  data
                .ToDictionary(x => x.Field, x => new SpecFlowData
                {
                    Value = x.Value,
                    Position = x.Position, 
                    Length = x.Length
                });
       return result;
    }
