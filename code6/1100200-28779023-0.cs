    IEnumerable Get()
    {
        var groups = _myDatas.GroupBy(
            // Key selector
            data => new {
                Type = data.GetType(),
                Id = data.ClassId,
                Value = data.Value
            },
            // Element projector
            (key, rows) => new 
            {
               ClassId = key.Id,
               TypeOfObject = key.Type,
               Value = key.Value,
               Count = rows.Count()
            }
        );
        
        return groups;
    }
