    public class PlayersCollection : IWorldCollection<PlayerModel>
    {
    
        public Dictionary<Type, object> Collection;
    
        public PlayersCollection()
        {
            Collection = new Dictionary<Type, object>();
        }
    
        public PlayerModel Get<PlayerModel>(int id)
        {
            ///
        }
      }
    }
    
    
    public interface IWorldCollection<T>
    {
        T Get<T>(int id);
    }
