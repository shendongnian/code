    public class Manager<T> where T : class, IBallgame
    {
        T GetManager()
        {
            //if T is ISoccer return new Soccer()
            //if T is IFootball return new Football()
    
            if (typeof(T) == typeof(ISoccer))
                return new Soccer() as T;
    
            //code
        }
    }
    
    public interface IBallgame
    {
    
    }
    public interface ISoccer : IBallgame
    {
    }
    public class Soccer : ISoccer
    {
    }
    public interface IFootball : IBallgame
    {
    }
    class Football : IFootball
    {
    }
