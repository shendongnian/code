    public static string StringTokenizr<T>(
           this List<T> list, 
           NpStringTokenizrType type, 
           string splitter = ",")
    {
       return string.Join(",", list.ConvertAll(name => string.Format(type == NpStringTokenizrType.StringLike ? "'{0}'" : "{0}", name.ToString().Replace("'", "\\'"))));
    }
