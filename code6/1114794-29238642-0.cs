    public class ControllerTypeWrapper<T> : ControllerTypeWrapper
    	where T : IController
    {
    	public Type Type {get {return typeof(T);}}
    }
    
    public class ControllerTypeWrapper
    {
    	// This should only be extended by ControllerTypeWrapper<T>
    	internal ControllerTypeWrapper(){}
    }
