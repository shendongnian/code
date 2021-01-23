    public class Manager<T> where T: IBallGame, new()
    {
        T GetManager()
        {
             return new T();         
        }
    }
