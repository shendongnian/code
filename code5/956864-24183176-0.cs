    public static string ToCommaList<T>(this IEnumerable<T> val) where T:class
            {
                if (val.Count() == 0)
                    return string.Empty;
               StringBuilder sb=new StringBuilder();
                if (typeof(T) == typeof(int))
                {
                    var strng = val.Select(x => x.ToString());
                    foreach (var str in strng)
                    {
                        sb.AppendFormat("{0},", str);
                    }
                    return sb.ToString().Trim(new char[] { ',' });
                }
                else if (typeof(T) == typeof(string))
                {
                    foreach (var str in val)
                    {
                        sb.AppendFormat("{0},", str);
                    }
                }
                return sb.ToString().Trim(new char[] { ',' });
            }
