            var names = new List<string>();
            names.Add("alice");
            names.Add("bob");
            names.Add("charlie");
            var digitMap = new Dictionary<int, string>()
	        {
		        { 1, "" },
		        { 2, "[abcABC]" },
		        { 3, "[defDEF]" },
		        { 4, "[ghiGHI]" },
		        { 5, "[jklJKL]" },
		        { 6, "[mnoMNO]" },
		        { 7, "[pqrsPQRS]" },
		        { 8, "[tuvTUV]" },
		        { 9, "[qxyzQXYZ]" },
		        { 0, "" },
	        };
            var enteredDigits = "26";
            var charsAsInts = enteredDigits.ToCharArray().Select(x => int.Parse(x.ToString()));
            var regexBuilder = new StringBuilder();
            foreach (var val in charsAsInts)
                regexBuilder.Append(digitMap[val]);
            var pattern = regexBuilder.ToString();
            //append a ".*" to the end of the regex to make it "StartsWith", beginning for "EndsWith", or both for "Contains";
            pattern = ".*" + pattern + ".*";
            var matchingNames = names.Where(x => Regex.IsMatch(x, pattern));
            Console.WriteLine("Matching input: " + enteredDigits + " as regex: " + pattern);
            foreach (var n in matchingNames)
                Console.WriteLine(n);
