    using (dbEntities context = new dbEntities())
                {
                    var rec = await context.Table1.Where(entity => id1id2Strings .Contains(entity.Id1+ "-" + entity.Id2));
                    return rec.ToList();
                }
