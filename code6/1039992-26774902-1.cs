    var errorsAsDict = (from entity in errors
                        from error in entity.ValidationErrors
                        select new { Entity = entity, Error = error})
                    .ToDictionary(
                       key => key.entity.Entry.Entity.GetType().FullName + "." + key.Error.PropertyName, 
                       value => value.Error.ErrorMessage);
