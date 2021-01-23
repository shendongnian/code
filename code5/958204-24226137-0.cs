    string FormatWithSearchTerms(string input, HashSet<string> keywords)
    {
            Regex r = new Regex(@"\b\w+\b"); // look for individual words.  (Note: refinement may be needed for special cases, like words with embedded punctuation.)
            return r.Replace(input, (m) =>
            {
                string v = m.Groups[0].Value;
                if (keywords.Contains(v))
                    return String.Format("<b>{0}</b>", v);
                else return v;
            });
    }
