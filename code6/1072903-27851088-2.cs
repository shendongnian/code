    public abstract class Model
    {
    }
    public class PlayerModel : Model
    {
    }
    public interface IWorldCollection<T> where T : Model
    {
        T Get<T>(int id);
    }
    public class PlayersCollection : IWorldCollection<PlayerModel>
    {
        ///
    
        public PlayerModel Get<PlayerModel>(int id)
        {
            ///
        }
      }
    }
