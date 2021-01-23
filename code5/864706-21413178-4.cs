    List<Action> actionList = new List<Action>();
    actionList.add( () => ProcessData("data")); // ProcessData is a void with no return type
    actionList.add( () => ProcessData(2));
    public void ProcessActions(List<Action> actions)
    {
        foreach(var action in actions)
        {
            action();
        }
    }
