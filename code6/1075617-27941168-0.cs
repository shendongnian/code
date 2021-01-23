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
                        propInfo.SetValue(this, Convert.ChangeType(value, propInfo.PropertyType), null);
                    }
                }
                catch (Exception e)
                {
                       //Log, alert do something!
                }
            }
        }
