    var res = DBcontext.EntityTable.Select(x => new
                    {
                        ID = x.ID,
                        Title = x.Title,
                        IsOpenAndHasHasOpenRelations = x.IsOpen ? false
                        : x.RootID != null ? DBcontext.EntityTable.Any(y => y.ID == x.RootID && y.IsOpen)
                        : (DBcontext.EntityTable.Any(y => y.ID == x.RootID && y.IsOpen))
                    });
