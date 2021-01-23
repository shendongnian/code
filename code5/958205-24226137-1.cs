    string FormatWithSearchTerms(string input, HashSet<string> keywords)
    {
            Regex r = new Regex(@"\b\w+\b"); // find individual words.  (Note: refinement may be needed for special cases, like words with embedded punctuation.)
            return r.Replace(input, (m) =>
            {
                string v = m.Value;
                if (keywords.Contains(v))
                    return m.Result("<b>$0</b>");
                else return v;
            });
    }
