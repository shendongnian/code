    var query = from rt in Repo.GetAll<ResultType>()
                join rj in Repo.GetAll<Result>() on rt.Id equals red.ResultType.Id into j
                from r in j.DefaultIfEmpty()
                group new { rt, r } by rt.DisplayName into g
                select new {
                    Name = g.Key,
                    Count = g.Where(x => x.r != null).Count()
                }
    
