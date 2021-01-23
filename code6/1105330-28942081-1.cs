    var rawStrings = from keys in keyTable
                    join values in valuesTable
                    on keys.ID equals values.FK_TableKey
                    select new {
                        Value = values.Value,                                        
                        keys.Key,
                        keys.Context
                    };
    var myStrings = rawStrings.AsEnumerable().Select(t => new NewModel {
         Value = t.Value,
         Hash = CalculateHash(string.Format("{0}_{1}", t.Key, t.Context))
    });
