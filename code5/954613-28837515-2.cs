    readonly Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
    void LoadCommands()
    {
        Type[] types = Assembly.GetExecutingAssembly().GetExportedTypes();
        var iCommandInterface = typeof(ICommand);
        foreach (Type type in types)
        {
            object[] attributes = type.GetCustomAttributes(typeof(CommandClassAttribute), false);
            if (attributes.Length == 0) continue;
            if (iCommandInterface.IsAssignableFrom(type))
            {
                string commandName = ((CommandClassAttribute)attributes[0]).CommandName;
                commands.Add(commandName, (ICommand)Activator.CreateInstance(type));
            }
        }
    }
