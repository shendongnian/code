    public static IEnumerable<Match> Matches(string input, string pattern) {
            int i = 0;
            while (i < input.Length){
                Match m = Regex.Match(input.Substring(i), "[A-Z]{2}");
                if (m.Success) {
                    yield return m;
                    i += m.Index + 1;
                }
                else yield break;
            }
    }
    //Use it
    var matches = Matches(input, "[A-Z]{2}");
