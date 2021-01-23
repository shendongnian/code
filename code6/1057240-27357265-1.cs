    public class BaseEnemy: MonoBehaviour, ISerializable 
    {
        //...
        protected BaseEnemey(SerializationInfo info, StreamingContext context)
        {
            //map all your properties here
            this.isAlive = info.GetBoolean("isAlive");
            //...
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("isAlive", isAlive);
            //...
        }
    }
