    class CommonError
    {
        public Regex Pattern { get; private set; }
        public string Message { get; private set; }
        public List<KeyValuePair<int, IEnumerable<string>>> Details { get; private set; }
        public CommonError(Regex pattern, string message)
        {
            Pattern = pattern;
            Message = message;
            Details = new List<KeyValuePair<int, IEnumerable<string>>>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //take a file read it once and while reading each line check if that line matches any of a slew of regexes.
            //if it does match a regex then add the line number and the matching text into a collection of matches for that regex.
            //at the end output all the matches by regex and the totals for each pattern. Along with printing each match also print the line it was found on. 
            var errorsToFind = new List<CommonError>()
            { 
               new CommonError(new Regex(@"access-group\s+\w+\s+out\s+interface\s+\w+"), "ACls installed by using access-group using the keyword OUT are NOT supported"),
               new CommonError(new Regex(@"^(?=.*\baccess-list\b)(?=.*\beq echo-reply\b).*$"), "Echo-reply is not necessary")
            };
            var errorsFound = FindCommonErrorsInFile(".\\test-file.txt", errorsToFind);
            foreach (var error in errorsFound)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("total incidences found: " + error.Details.Count);
                error.Details.ForEach(d => Console.WriteLine(string.Format("Line {0} {1}", d.Key, string.Join(",", d.Value))));
            }
        }
        static IEnumerable<CommonError> FindCommonErrorsInFile(string pathToFile, IEnumerable<CommonError> errorsToFind)
        {
            var lineNumber = 1;
            foreach (var line in File.ReadLines(pathToFile))
            {
                foreach (var error in errorsToFind)
                {
                    var matches = error.Pattern.Matches(line);
                    if(matches.Count == 0) continue;
                    
                    var rawMatches = matches.Cast<Match>().Select(m => m.Value);
                    error.Details.Add(new KeyValuePair<int, IEnumerable<string>>(lineNumber, rawMatches));
                }
                lineNumber++;
            }
            return errorsToFind.Where(e => e.Details.Count > 0);
        }
    }
