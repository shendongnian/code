       list.Where(j => j.Loaded == null).Take(10).AsEnumerable()
                    .Select(x =>
                    {
                        x.Loaded = DateTime.UtcNow;
                        db.SaveChanges();
                        return x;
                    })
                    .ToList().ForEach(j => //proccess job here);
