    using Dapper;
    using (var c = new SqlConnection(connectionString))
    {
        c.Open();
        c.Execute(string.Format("UPDATE ItemSet SET Enable = 0 WHERE Id NOT IN ({0})",
                            BuildIds(newItems.Select(x => x.Id).ToList()));
    }    
    public static class SqlHelpers
    {
        internal static string BuildIds<T>(IReadOnlyList<T> ids)
        {
            if (ids.Count <= 0)
                return "''";
    
            var agsb = new StringBuilder(string.Format("'{0}'", ids[0]));
            for (var i = 1; i < ids.Count; i++)
            {
                agsb.AppendFormat(", '{0}'", ids[i]);
            }
    
            return agsb.ToString();
        }
    }
