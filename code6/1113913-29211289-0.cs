    var objects = from p in db.full
                  where (p.mc_object.Contains(str))
                  group p by p.mc_object into g
                  orderby g.Count() descending
                  select new StringIntType
                  {
                      str = g.Key,
                      nbr = g.Count(),
                      par="object"
                  };
    var owner = from p in db.full
                where (p.mc_owner.Contains(str))
                group p by p.mc_owner into g
                orderby g.Count() descending
                select new StringIntType
                {
                    str = g.Key,
                    nbr = g.Count(),
                    par="owner"
                };
    maList = objects.Concat(owner).ToList();
