        var dto2 = rd.EngDetailBitsList(dto.EngId);
        var dto3 = rd.EngDetailDateTimesList(dto.EngId);
        var dto4 = rd.EngDetailVarCharsList(dto.EngId);
        var dto5 = rd.EngDetailVarCharMaxesList(dto.EngId);
        var source = dto2.Cast<MyInterface>
                         .Concat(dto3.Cast<MyInterface>)
                         .Concat(dto4.Cast<MyInterface>)
                         .Concat(dto4.Cast<MyInterface>);
                              
        var dtoType = dto.GetType();
        foreach (var x in source)
        {
            var propertyInfo = dtoType.GetProperty(x.ShortDescript,
                   BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(dto, x.DataValue);
            }
        }
