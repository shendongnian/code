    public class Manager<T> 
    {
    T GetManager()
    {
    //if T is ISoccer return new Soccer()
    //if T is IFootball return new Football()
    
    //This wont work. Why? Soccer implements ISoccer.
    if (typeof(T) == typeof(ISoccer))
                    return new Soccer();
    else if (typeof(T) == typeof(IFootball))
                    return new Football();
    else throw new InvalidOperationException();
    
    }
    }
