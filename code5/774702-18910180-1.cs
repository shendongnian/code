    DataTable MyTable = new DataTable();// Yur Table here
                    var FirstResult = from Row in MyTable.AsEnumerable()
                                      orderby Row.Field<int>("Index")
                                      select new
                                      {
                                          KioskId = Row.Field<string>("KioskId"),
                                          Index = Row.Field<int>("Index"),
                                          FileName = Row.Field<string>("FileName")
        
                                      };
                    var AfterRowNumbering = FirstResult.Select((x, index) => new  {
                        KioskId=x.KioskId,
                        Index=x.Index,
                        FileName = x.FileName,
                        Row_Number = index
                   }).Take(5);
