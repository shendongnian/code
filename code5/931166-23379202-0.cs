    internal static class CommandExtensions
    {
        public static Command AddCommand(this Pipeline pipeline, string command)
        {
            var com = new Command(command);
            pipeline.Commands.Add(com);
            return com;
        }
        public static Command AddParameter(this Command command, string parameter)
        {
            command.Parameters.Add(new CommandParameter(parameter));
            return command;
        }
        public static Command AddParameter(this Command command, string parameter, object value)
        {
            command.Parameters.Add(new CommandParameter(parameter, value));
            return command;
        }
    }
