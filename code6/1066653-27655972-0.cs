    var commands = typeof(Command)
        .Assembly
        .GetTypes()
        .Where(p => p.IsClass)
        .Where(p => p.BaseType != null && p.BaseType.Name.StartsWith("CommandBase"));
    
                
    var CommandsCache = new List<Command>();
    
    foreach (var c in commands)
    {
        CommandsCache.Add((Command)Activator.CreateInstance(c));
    }
