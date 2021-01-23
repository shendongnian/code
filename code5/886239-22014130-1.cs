     var result = _Repository.Get()
            .Skip(query.Skip)
            .Take(query.Top)
            .Where(el => !el.disabled && el.FieldToMatch == query.Filter)
            .Select(x => new {
                x.Id,
                x.Text,
                x.Date
            });
      return result;
