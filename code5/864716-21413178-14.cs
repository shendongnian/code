    List<Action> actionList = new List<Action>();
    actionList.Add( () => ProcessData("data")); // ProcessData is a void with no return type
    actionList.Add( () => ProcessData(2));
    public void ProcessActions(List<Action> actions)
    {
        foreach(var action in actions)
        {
            action();
        }
    }
