    // Parse input arguments, expected format is "<key>:<value>"
    public class InputArgumentsParser
    {
        private const char ArgSeparator = ':';
        private Dictionary<string[],Action<string>> ArgAction = 
            new Dictionary<string[], Action<string>>();
        public InputArgumentsParser()
        {
            // Supported actions to take, based on args
            ArgAction.Add(new[] { "/f", "/file" }, (param) => 
                Console.WriteLine(@"Received file argument '{0}'", param));
        }
        /// Parse collection
        public void Parse(ICollection<string> args)
        {
            if (args == null || !args.Any())
                return;
            foreach (string arg in args)
            {
                // Extract key/value pair
                string[] parts = arg.Split(ArgSeparator);
                if (parts.Length != 2)
                    continue;
                // Execute action if found
                foreach (var key in ArgAction.Keys)
                {
                    if (key.Contains(parts[0].ToLowerInvariant()))
                    {
                        ArgAction[key].Invoke(parts[1]);
                        break;
                    }
                }
            }
        }
    }
