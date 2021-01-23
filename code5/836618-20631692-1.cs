    public abstract class BaseClass
    {
      public void Start()
      {
        // do something
        OnStart();
        // do something else
      }
      protected abstract void OnStart();
    }
