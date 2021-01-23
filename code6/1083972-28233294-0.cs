    public static IList<T> SplitStringUsing(string source, string seperator =",")
        {
             return source.Split(Convert.ToChar(seperator))
                          .Select(x => x.Trim())
                          .Where(x => !string.IsNullOrWhiteSpace(x))
                          .Select((T)Convert.ChangeType( x, typeof( T ) )).ToList();
        }
