                using (var ctx = GetContext())
                {
                    int[] ids = ctx.Bs.Select(x => x.Id).ToArray();
                    foreach (Bs b in A1.BsCollection)
                    {
                        if (!ids.Contains(b.Id))
                            ctx.Bs.Add(b);
                        else if(...){ ... }
                    }
                    ctx.As.Attach(A1);
                    ctx.Entry(A1).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
