    public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortExpression)
            {
                sortExpression += "";
                string[] parts = sortExpression.Split(' ');
                bool descending = false;
                string property = "";
     
                if (parts.Length > 0 && parts[0] != "")
                {
                    property = parts[0];
     
                    if (parts.Length > 1)
                    {
                        descending = parts[1].ToLower().Contains("esc");
                    }
     
                    PropertyInfo prop = typeof(T).GetProperty(property);
     
                    if (prop == null)
                    {
                        throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
                    }
     
                    if (descending)
                        return list.OrderByDescending(x => prop.GetValue(x, null));
                    else
                        return list.OrderBy(x => prop.GetValue(x, null));
                }
     
                return list;
            }
