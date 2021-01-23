    var qbase2 = qbase.AsEnumerable().Select(x => new
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            DynamicCol = (int)s.GetType().GetProperty("Col1").GetValue(x, null) ,
            //Remember to cast the dynamic column according to its datatype
            items =  x.Col1.Where(xx => xx.Id2 == x.Id).GroupBy(b=>b.Id2).Select(y =>
                new
                { 
                    Bed = y.Sum(c=>c.Bed),
                    Bes = y.Sum(c => c.Bes),
                })                  
        }); 
