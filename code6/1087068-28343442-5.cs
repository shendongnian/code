    public class InputArgumentsParser
    {
        private const char ArgSeparator = ':';
        private Dictionary<string[],Action<string>> ArgAction = 
            new Dictionary<string[],Action<string>>();
        public InputArgumentsParser()
        {
            // Supported actions to take, based on args
            ArgAction.Add(new[] { "/f", "/file" }, (param) => 
                Console.WriteLine(@"Received file argument '{0}'", param));
        }
        /// Parse collection, expected format is "<key>:<value>"
        public void Parse(ICollection<string> args)
        {
            if (args == null || !args.Any())
                return;
            // Iterate over arguments, extract key/value pairs
            foreach (string arg in args)
            {
                string[] parts = arg.Split(ArgSeparator);
                if (parts.Length != 2)
                    continue;
                // Find related action and execute if found
                var action = ArgAction.Keys.Where(key => 
                    key.Contains(parts[0].ToLowerInvariant()))
                        .Select(key => ArgAction[key]).SingleOrDefault();
                
                if (action != null)
                    action.Invoke(parts[1]);
                else
                    Console.WriteLine(@"No action for argument '{0}'", arg);
            }
        }
    }
