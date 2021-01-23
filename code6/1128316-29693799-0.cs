    public class GameObjectImplementation: IGameObject
    {
        public Vector3 GetSomePosition(){
           return null;
        }
    }
    
    public class Player : GameObjectImplementation, IPlayer
    {
        public void Die() { }
    }
