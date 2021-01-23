    public class RandomStringReplacer
    {
        // no need to seed this w/ the current time, the default constructor does that already
        private readonly Random _random = new Random();
    
        private readonly Regex _regex;
    
        private readonly string[] _replacementStrings;
        
        public RandomStringReplacer(string pattern, params string[] replacementStrings)
        {
            _regex = new Regex(pattern);
            _replacementStrings = replacementStrings.ToArray();
        }
	
        // each time we get a replacement string, a randomly selected one is chosen
        private string RandomReplacement
        {
            get { return _replacementStrings[_random.Next(_replacementStrings.Length)]; }
        }
	
        public string Replace(string text)
        {
            var random = new Random();
            var result = text;
            
            // get the matches as a stack, because we want to replace backwards so that indexes still match the correct spot in the string
            var matches = new Stack<Match>(_regex.Matches(text).OfType<Match>());
            while (matches.Count > 0)
            {
                var match = matches.Pop();
                // each match has a 1/3 chance to be replaced
                if (random.Next(3) == 0)
                {
                    result = result.Remove(match.Index, match.Length).Insert(match.Index, RandomReplacement);
                }
            }
            return result;
        }
    }
