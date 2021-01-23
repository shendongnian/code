    internal class ActionService<T>
    {
    	private static ActionService<T> instance;
    	private readonly List<ServiceAction<T>> registeredActions;
    
    	private ActionService()
    	{
    		registeredActions = new List<ServiceAction<T>>();		
    	}
    
    	internal static ActionService<T> Instance()
    	{
    		return instance ?? (instance = new ActionService<T>());
    	}
    
    	internal void Subscribe(string actionName, Action<T> action)
    	{
    		registeredActions.Add(new ServiceAction<T>(actionName, action));
    	}
    
    	internal void Unsubscribe(string actionName)
    	{
    		registeredActions.RemoveAll(action => action.ActionName == actionName);
    	}
    
    	internal void Invoke(string actionName, T parameter)
    	{
    		foreach (ServiceAction<T> action in registeredActions.Where(action => action.ActionName == actionName).ToArray())
    		{
    			action.Action.Invoke(parameter);
    		}
    	}
    
    	private class ServiceAction<TSub>
    	{
    		internal ServiceAction(string actionName, Action<TSub> action)
    		{
    			ActionName = actionName;
    			Action = action;
    		}
    
    		internal string ActionName { get; private set; }
    		internal Action<TSub> Action { get; private set; }
    	}
    }
