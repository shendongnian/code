    public class CMDReader
    {
        delegate void CmdHandler(string[] cmdArgs); // Or Action<string[]>
        
        private readonly IDictionary<string, CmdHandler> _commands;
        public CMDReader()
        {
            _commands = new Dictionary<string, CmdHandler>
            {
                {
                    "Print", Print
                },
                {
                    "Help", Help
                },
            };
        }
        public void InvokeCommand(string command, string[] args)
        {
            _commands[command].Invoke(args);
            // OR (_commands[command])(args);
        }
        private void Print(string[] args)
        {
          // Implementation
        }
        private void Help(string[] args)
        {
          // Implementation
        }
    }
