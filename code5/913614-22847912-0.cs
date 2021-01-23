    List<Svs> svsList = (from s in db.Svs
                         where s.Env.UID.Equals(env)
                         select new
                         {
                             Svs = s,
                             Cons = from c in s.Cons
                                    where c.Apps.Any(a => a.AppT.Type.Equals(appT))
                                    select c
                         })
                         .AsEnumerable()
                         .Select(sWithA =>
                         {
                             sWithA.Svs.Cons = sWithA.Cons.ToList();
                             return sWithA.Svs;
                         })
                         .ToList(); 
