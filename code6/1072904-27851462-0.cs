    public class PlayersCollection<T> : IWorldCollection<T> where T:PlayerModel
    {
    public Dictionary<Type, object> Collection;
    public PlayersCollection()
    {
        Collection = new Dictionary<Type, object>();
    }
    public T Get(int id)
    {
        ...
    }
    }
    public interface IWorldCollection<T> where T:class
    {
        T Get(int id);
    }
