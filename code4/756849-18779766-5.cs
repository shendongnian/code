    static readonly Dictionary<Action.Kind, Type> actionTypes = 
       GetDefaultInstanceOfAllActions().ToDictionary(x => x.ActionType, x => x.GetType());
    public static Action ToAction(this Action.Kind value)
    {
        return (Action)Activator.CreateInstance(actionTypes[value]);
    }
