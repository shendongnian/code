    DataTable dt = TableB.Clone();
    dt = TableA.AsEnumerable().Join(TableB.AsEnumerable(),
                                    row=>row.Field<string>(0),
                                    row=>row.Field<string>(0), (a,b)=> new {a,b})
            .Select(pair=> {
              DataRow row = dt.NewRow();
              row.SetField<string>(0, pair.a.Field<string>(0));
              for(int i = 1; i < 5; i++){                
                row.SetField<decimal>(i, pair.a.Field<decimal>(i) == 
                                         pair.b.Field<decimal>(i) ?
                                        0 : Math.Max(pair.a.Field<decimal>(i),
                                                     pair.b.Field<decimal>(i));
              }
              return row;
           }).Where(row=>Enumerable.Range(1,4).Any(i=>row.Field<decimal>(i) > 0))
             .CopyToDataTable();
