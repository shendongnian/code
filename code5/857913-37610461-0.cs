    public static List<string> GetCommandLineArguments(string commandline){
    	var arguments = Regex.Matches(commandline, @"[\""].+?[\""]|[^ ]+")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToList();
    	return arguments;
    }
