    public class BaseClient<T> where T : ITimeable
    {
        public T TimedDoorObject;
        public virtual void Init()
        {
            Timer.Add((ITimeable)TimedDoorObject);
        }
    }
    
    public class Client : BaseClient<TimedDoor>
    {
        public Client()
        {
            TimedDoorObject = new TimedDoor();
        }
    
        public override void Init()
        {
            Timer.Add((TimedDoor)TimedDoorObject);
        }
    }
