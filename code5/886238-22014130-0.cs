     var result = _Repository.Get()
            .Skip(query.Skip)
            .Take(query.Top)
            .Select(x => new {
                x.Id,
                x.Text,
                x.Date
            }).FirstOrDefault();
            return result;
    }
