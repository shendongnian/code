    public string GetMyCharacters(string s)
            {
                int numOfCaps = Regex.Matches(s, "[A-Z]").Count;
                if (numOfCaps > 2)
                {
                    var matches = Regex.Matches(s, "[A-Z][a-z]{2}");
                    return matches[0].Value + matches[1].Value;
                }
                else if (numOfCaps == 1)
                {
                    var matches = Regex.Matches(s, "[A-Z][a-z]{2}");
                    return matches[0].Value;
                }
                else { return null; }
            }
