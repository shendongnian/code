    from p in GetPersonList()
        join c in backEnd.GetCarList()
         on p.PId equals c.PId
            into joinResults
        from c in joinResults.DefaultIfEmpty()
        orderby p.PId descending
        select new Person
        {
            PName = p.PName,
            PId = p.PId,
            CModel = c == null ? ( CModel )null : c.CModel,
        }).ToList()
