    private static string RemovePartialTags(string input)
        {
            Regex regex = new Regex(@"<[^<>/]+>(.*?)[<](.*?)<[^<>]+>");
            string output = regex.Replace(input, delegate(Match m)
                    {
                        string v = m.Value;
                        Regex reg = new Regex(@"<[^<>]+>");
                        MatchCollection matches = reg.Matches(v);
                        int locEndTag = v.IndexOf(matches[1].Value);
                        List<string> tokens = new List<string>
                                {
                                    v.Substring(0, matches[0].Length),
                                    v.Substring(matches[0].Length, locEndTag - matches[0].Length)
                                        .Replace(@"<", string.Empty)
                                        .Replace(@">", string.Empty)
                                };
                        tokens.Add(v.Substring(tokens[0].Length + (locEndTag - matches[0].Length)));
                        return tokens[0] + tokens[1] + tokens[2];
                    }
                );
            return output;
        }  
