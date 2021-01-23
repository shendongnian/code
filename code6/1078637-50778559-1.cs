    public static class ConnectionExtensions
    {
        public static IEnumerable<T> QueryIncludeNestedObjects<T>(this SqlConnection connection, string sql)
        {
            var queryResults = connection.Query<dynamic>(sql);
            var typeOfTMain = typeof(T);
          
            foreach(var row in queryResults)
            {
                var mappedObject = Activator.CreateInstance<T>();
                foreach (var col in row)
                {
                    var colKey = (string)col.Key;
                    var colValue = (object)col.Value;
                    if(colKey.Contains("_"))
                    {
                        var subObjNameAndProp = colKey.Split('_');
                        var subProperty = typeOfTMain.GetProperty(subObjNameAndProp[0]);
                        if (subProperty == null) continue;
                        var subObj = subProperty.GetValue(mappedObject);
                        if(subObj == null)
                        {
                            subObj = Activator.CreateInstance(subProperty.PropertyType);
                            typeOfTMain.GetProperty(subObjNameAndProp[0]).SetValue(mappedObject, subObj);
                        }
                        subObj.GetType().GetProperty(subObjNameAndProp[1])
                            .SetValue(subObj, colValue);
                    }
                    else
                        typeOfTMain.GetProperty(colKey)?.SetValue(mappedObject, colValue);
                   
                }
                yield return mappedObject;
            }
        }
    }
