            IEnumerable<string> allInputs = new[] {"70000", "89000", "89001", "90001"};
            string commaSeparatedPostCodePatterns = @"89000,90\d\d\d"; // USE REGEX SYNTAX 
            
            if (string.IsNullOrWhiteSpace(commaSeparatedPostCodePatterns)) 
                return;
            string[] postCodePatterns = commaSeparatedPostCodePatterns.Split(',');
            var allMatches = 
                allInputs.Where(input => postCodePatterns.Any(pattern => Regex.IsMatch(input, pattern)));
            foreach (var match in allMatches)
                Console.WriteLine(match);
