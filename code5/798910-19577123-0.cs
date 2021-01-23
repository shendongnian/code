    var RoomData= from table in sqlResults.AsEnumerable()
                  group table by table["Room"] into groupby 
                  from g in groupby
                  where g.Any(row=>row["PERSON"] != null)                        
                  select new TreeViewDataItem {
                         RoomName = g.Key.ToString(),
                         PersonList = g.Where(row=>row["PERSON"] != null)
                                       .Select(row => new PersonInfo{
                                         Name = row["PERSON"].ToString(),
                                         Id = row.Field<Int32?>("PERSONID")
                                        }).ToList()
                  };
