    var datas = _inputTable.AsEnumerable()
            .GroupBy(r => r.Field<string>("ItemName"))
            .Select(r => 
                new Data
                {
                    Key = r.Key, 
                    Values = r.Select(x => x.Field<string>("ItemValue")).ToList()
                });
     foreach (var data in datas)
     {
        SomeMethod(data);    
     }
