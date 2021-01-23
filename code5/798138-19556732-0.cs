     var entity= dataContext.Properties.Find(b => b.UniqueId == poco.UniqueId);
                        if (entity== null)
                        {
                            dataContext.Properties.Add(poco);
                        }
                        else
                        {
                           dataContext.Entry(entity).State = EntityState.Modified;
                        }
                       dataContext.SaveChanges();
