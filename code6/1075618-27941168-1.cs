        public void HydrateFromToString(string serialised)
        {
            var currentType = GetType();
            foreach (var keyValuePair in serialised.Split(new[]{','}))
            {
                var trimmedKeyValuePair = keyValuePair.Trim();
                var splitted = trimmedKeyValuePair.Split(new[] {':'}, 2);
                if(splitted.Length != 2)
                {
                    throw new ArgumentException("There is no comma to separate this keyValuePair : "+trimmedKeyValuePair);
                }
                var propertyName = splitted[0].Trim();
                var value = splitted[1].Trim();
                var propInfo = currentType.GetProperty(propertyName);
                try
                {
                    if (propInfo.GetSetMethod() != null)
                    {
                        var propertyType = propInfo.PropertyType;
                     
                        if (propertyType.IsEnum)
                        {
                            if (!Enum.IsDefined(propertyType, value))
                                    throw new ArgumentException("Enum value not handled!");
                            propInfo.SetValue(this,  Enum.Parse(propertyType, value), null);
                            continue;
                        }
                        propInfo.SetValue(this, Convert.ChangeType(value, propertyType), null);
                    }                }
                catch (Exception e)
                {
                       //Log, alert do something!
                }
            }
        }
