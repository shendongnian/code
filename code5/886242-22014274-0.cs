     var result = _Repository.Get()
                    .Skip(query.Skip)
                    .Take(query.Top)
                    .Where(x => 
                          x.disabled == false &&
                          x.FilterField == query.Filter)
                    )
                    .Select(x => new {
                        x.Id,
                        x.Text,
                        x.Date
                    });
                    return result;
            }
