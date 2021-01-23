    public static List<ExpandoObject> MapColumnsAndGetResult<T>(List<T> YourDataInList, string[] ColumnNames)
        {
            var result = new List<ExpandoObject>();
            foreach (var objClass in YourDataInList)
            {
                if (objClass != null)
                {
                    var dynamicClass = new ExpandoObject() as IDictionary<string,object>;
                    foreach (var prop in objClass.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                    {
                        if (ColumnNames.Contains(prop.Name))
                        {
                            dynamicClass.Add(prop.Name, prop.GetValue(objClass, null));
                            result.Add((ExpandoObject)dynamicClass);
                        }
                    }
                }
            }
            result = result.Distinct().ToList();
            return result;
        }
