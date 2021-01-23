    public static IEnumerable<T> OrderByString<T>(this IEnumerable<T> entities, string sortExpression)
            {
                 
                bool descending = sortExpression.ToLowerInvariant().Trim().EndsWith("desc");
     
                PropertyInfo[] propertyInfos = typeof(T).GetProperties();
                // sort properties by name
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    if (sortExpression.Split(' ')[0] == propertyInfo.Name)
                    {
                        PropertyInfo info = propertyInfo;
                        if (descending)
                            return entities.OrderByDescending(c => info.GetValue(c, null));
                        else
                            return entities.OrderBy(c => info.GetValue(c, null));
                    }
                }
                return entities;
            }
