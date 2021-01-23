     Datatable1.AsEnumerable()
               .Join(Datatable2.AsEnumerable(),
                     dt1row => dt1row.Field<string>("name"),
                     dt2row => dt2row.Field<string>("name")) ,
                     (dt1row, dt2row) => new { dt1row, dt2row })
               .Select((row, index)=> new 
                      {
                          Index=index, 
                          Dt1row = row.dt1row, 
                          Dt2row = row.dt2row
                      }).ToList()
                        .ForEach(o =>
                        {
                            //check if value for fields is the same in 
                        });
