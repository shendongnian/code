    protected override void Execute()
    {
        var agent = this.Context.Agent.GetService<IFileOperationsExecuter>();
        var entry = agent.GetDirectoryEntry(new GetDirectoryEntryCommand() { Path = dataPath }).Entry;
        foreach(var file in entry.Files) 
        {
            string contents = agent.ReadAllText(file.Path);
            this.LogInformation(contents);
        }
    }
