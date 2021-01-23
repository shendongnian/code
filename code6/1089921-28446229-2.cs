    public List<Datum> FindEquals(String varName, String value)
            {
                List<Datum> results = new List<Datum>();
                var propertyInfo = (typeof Datum).GetProperty(varName);
                foreach (Datum result in data)
                {
                    String varValue = (string)propertyInfo.GetValue(result, null);
                    if (varValue == value)
                        results.Add(result);
                }
                return results;
            }
