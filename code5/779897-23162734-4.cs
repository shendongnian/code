    public void Press()
    {
        DoAction("click");
    }
    
    protected void DoAction(params string[] actions)
    {
        API.AccessibleActionsToDo todo = new API.AccessibleActionsToDo()
        {
            actionInfo = new API.AccessibleActionInfo[API.MAX_ACTIONS_TO_DO],
            actionsCount = actions.Length,
        };
   
        for (int i = 0, n = Math.Min(actions.Length, API.MAX_ACTIONS_TO_DO); i < n; i++)
            todo.actionInfo[i].name = actions[i];
   
        Int32 failure = 0;
        if (!API.doAccessibleActions(this.VmId, this.Context, ref todo, ref failure))
            throw new AccessibilityException("Error performing action");
    }
