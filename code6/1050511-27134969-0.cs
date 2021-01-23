            var dto2 = rd.EngDetailBitsList(dto.EngId);
            var dto3 = rd.EngDetailDateTimesList(dto.EngId);
            var dto4 = rd.EngDetailVarCharsList(dto.EngId);
            var dto5 = rd.EngDetailVarCharMaxesList(dto.EngId);
            var source = dto2.Concat(dto3.Concat(dto4.Concat(dto5.Cast<dynamic>())));
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
