public static string ToSqlParamsString(this IDictionary<string, string> dict)
        {
            string result = string.Empty;
            foreach (var kvp in dict)
            {
                result += $"@{kvp.Key}='{kvp.Value}',";
            }
            return result.Trim(',', ' ');
        }
public static List<T> RunSproc<T>(string sprocName, IDictionary<string, string> parameters)
        {
            string command = $"exec {sprocName} {parameters.ToSqlParamsString()}";
            return Context.Database.SqlQuery<T>(command).ToList();
        }
