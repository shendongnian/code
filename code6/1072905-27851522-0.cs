    public class PlayersCollection<T> : IWorldCollection<T> where T : PlayerModel
    {
        public Dictionary<Type, object> Collection;
        public PlayersCollection()
        {
            Collection = new Dictionary<Type, object>();
        }
        public T Get(int id)
        {
           var t = typeof(T);
           if (!Collection.ContainsKey(t)) return null;
           var dict = Collection[t] as Dictionary<int, T>;
           if (!dict.ContainsKey(id)) return null;
           return (T)dict[id];
        }
      }
    public interface IWorldCollection<T> where T : class
    {
        T Get(int id);
    }
