    var _vals = new List<int>();
    var res = dbContext.Set<DT_Det_Tr>()
                .Where(obj => { dynamic x = obj;
                   return x.TrParent.DataTypes
                    .Select(t => t.Id)
                        .Intersect(_vals)
                            .Any();
                     }
                );
