    public static IList<string> SplitAndTrim(this string s, StringSplitOptions options, params string[] delimiters)
        {
            if (s == null)
            {
                return null;
            }
            var query = s.Split(delimiters, StringSplitOptions.None).Select(x => x.Trim());
            if (options == StringSplitOptions.RemoveEmptyEntries)
            {
                query = query.Where(x => x.Trim() != string.Empty);
            }
            return query.ToList();
        }
