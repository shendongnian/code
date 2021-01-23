            List<string> GetFieldNames(IEnumerable<FieldInfo> fields)
            {
                var results = new List<string>();
    
                foreach (var fieldInfo in fields)
                {
                    if (fieldInfo.FieldType.GetFields().Count() > 1)
                    {
                        results.AddRange(GetFieldNames(fieldInfo.FieldType.GetFields()));
                    }
                    else
                    {
                        results.Add(fieldInfo.Name);
                    }
                }
                return results;
            }
