        var dto2 = rd.EngDetailBitsList(dto.EngId);
        var dto3 = rd.EngDetailDateTimesList(dto.EngId);
        var dto4 = rd.EngDetailVarCharsList(dto.EngId);
        var dto5 = rd.EngDetailVarCharMaxesList(dto.EngId);
        ObjectSetter(new object() /* test only */, dto2, "DataValue");
        private void ObjectSetter(object dto, string dtoProp, 
            IEnumerable items, string itemProperty)
        {
            foreach (var item in items)
            {
                var propertyInfo = dto.GetType().GetProperty(dtoProp,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                var itemValue = dto.GetType().GetProperty(itemProperty,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(item, itemValue.GetValue(item));
                }
            }
        }
