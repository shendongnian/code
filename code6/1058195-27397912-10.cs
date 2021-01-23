    public class CommandManager
    {
        private readonly ConcurrentDictionary<Type, ICommandHandler> fCommands = new ConcurrentDictionary<Type, ICommandHandler>();
        public void FillCommandsList(Assembly[] commandDataAssemblies, Assembly[] commandAssemblies)
        {
            var data = new List<Type>();
            foreach (Assembly assembly in commandDataAssemblies)
                data.AddRange(assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICommand))));
            var commands = new List<Type>();
            foreach (Assembly assembly in commandAssemblies)
                commands.AddRange(assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICommandHandler))));
            foreach (Type dataType in data)
            {
                foreach (Type commandType in commands)
                {
                    Type commandDataType = commandType.GetCustomAttribute<CommandTypeAttribute>().CommandType;
                    if (commandDataType == dataType)
                    {
                        if (!fCommands.ContainsKey(dataType))
                        {
                            fCommands[dataType] = (ICommandHandler)Activator.CreateInstance(commandType);
                        }
                        else
                        {
                            throw new ArgumentException(string.Format("A command handler is already registered for the command: '{0}'. Only one command handler can be registered for a command", dataType.Name));
                        }
                    }
                }
            }
        }
        public void ExecuteCommand(ICommand command)
        {
            if (command == null)
                return;
            Type commandType = command.GetType();
            if (!fCommands.ContainsKey(commandType))
                throw new ArgumentException(string.Format("Command '{0}' not found", commandType.Name));
            ICommandHandler commandHandler = fCommands[commandType];
            commandHandler.Execute(command);
        }
    }
