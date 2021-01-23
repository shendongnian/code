    List<List<Action>> actions = InitializeActions();
    
    foreach(var list in actions)
    {
        foreach(var action in listCopy)
        {
            // Spawn a thread on each action.
            Task.Factory.StartNew(action);
        }
    }
