    DataTable dt = TableB.Clone();
    dt = TableA.AsEnumerable().Join(TableB.AsEnumerable(),
                                    row=>row.Field<string>(0),
                                    row=>row.Field<string>(0), (a,b)=> new {a,b})
            .Select(pair=> {
              DataRow row = dt.NewRow();
              row.SetField<string>(0, pair.a.Field<string>(0));
              bool notNull = false;
              for(int i = 1; i < 5; i++){ 
                var a = pair.a.Field<decimal>(i);
                var b = pair.b.Field<decimal>(i);
                if(a == b) row.SetField<decimal>(i, 0);
                else {
                   row.SetField<decimal>(i, Math.Max(a,b));
                   notNull = true;
                }
              }
              return notNull ? row : null;
           }).Where(row=>row != null).CopyToDataTable();
