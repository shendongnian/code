        static IEnumerable<Person> SearchStringTroughAllProperties(string stringToSearch, IEnumerable<Person> persons)
        {
            var properties =
                typeof (Person).GetProperties()
                    .Where(x => x.CanRead && (x.PropertyType == typeof (string) || x.PropertyType == typeof(string[])))
                    .Select(x => x.GetMethod)
                    .Where(x => !x.IsStatic)
                    .ToList();
            foreach (var person in persons)
            {
                foreach (var property in properties)
                {
                    bool yieldReturned = false;
                    switch (property.ReturnType.ToString())
                    {
                        case "System.String":
                            var propertyValueStr = (string) property.Invoke(person, null) ?? string.Empty;
                            if (propertyValueStr.Contains(stringToSearch))
                            {
                                yield return person;
                                yieldReturned = true;
                            }
                            break;
                        case "System.String[]":
                            var propertyValueStrArr = (string[]) property.Invoke(person, null);
                            if (propertyValueStrArr != null && propertyValueStrArr.Any(x => x.Contains(stringToSearch)))
                            {
                                yield return person;
                                yieldReturned = true;
                            }
                            break;
                    }
                    if (yieldReturned)
                    {
                        break;
                    }
                }
            }
        }
