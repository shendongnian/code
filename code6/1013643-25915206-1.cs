    public string SortTerm(string term) {
        Match match = Regex.Match(term, @"([a-z]\d{2})(-| vs )([a-z]\d{2})", RegexOptions.IgnoreCase);
        if (match.Success) {
            string left = match.Groups[1].Value;
            string mid = match.Groups[2].Value;
            string right = match.Groups[3].Value;
            int a = int.Parse(left.Substring(1));
            int b = int.Parse(right.Substring(1));
            if (a > b || (a == b && left[0] > right[0]))
                return right + mid + left;
        }
        return term;
    }
