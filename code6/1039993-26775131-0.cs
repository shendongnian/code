    var items = errors.SelectMany(entity => entity.Select(error => new { Entity = entity, Error = error }));
    foreach(var item in items)
    {
        validationErrors.Add(
            item.Entity.Entry.Entity.GetType().FullName 
                + "."
                + item.Error.PropertyName,
            errorMessage);
    }
