    public interface IRemoteFactory
    {
      IMySessionBoundObject GetInstance();
    }
    public class RemoteFactory : MarshalByRefObject, IRemoteFactory
    {
      public IMySessionBoundObject GetInstance()
      {
        // Return an already existing object, instead of a new one.
        return MyAlreadyExistingSessionBoundObject;
      }
    }
