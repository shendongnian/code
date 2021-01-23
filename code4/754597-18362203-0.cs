    // Helper function to turn the file search pattern in to a
    // regex pattern.
    private Regex BuildRegexFromPattern(String input)
    {
        String pattern = String.Concat(input.ToCharArray().Select(i => {
            String c = i.ToString();
            return c == "?" ? "(.)"
                : c == "*" ? "(.*)"
                : c == " " ? "\\s"
                : Regex.Escape(c);
        }));
        return new Regex(pattern);
    }
    
    // perform the actual replacement
    private IEnumerable<String> ReplaceUsingPattern(IEnumerable<String> items, String searchPattern, String replacementPattern)
    {
        Regex searchRe = BuildRegexFromPattern(searchPattern);
        
        return items.Where(s => searchRe.IsMatch(s)).Select (s => {
            Match match = searchRe.Match(s);
            Int32 m = 1;
            return String.Concat(replacementPattern.ToCharArray().Select(i => {
                String c = i.ToString();
                if (m > match.Groups.Count)
                {
                    throw new InvalidOperationException("Replacement placeholders exceeds locator placeholders.");
                }
                return c == "?" ? match.Groups[m++].Value
                    : c == "*" ? match.Groups[m++].Value
                    : c;
            }));
        });
    }
