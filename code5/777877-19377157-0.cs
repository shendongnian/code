    public interface IMyObjectFactory: IObjectWithProperty
    {
      int objectId { get; set; }
    }
    
    public interface IObjectWithProperty
    {
      IObjectWithProperty WithObjectId(int id);
      MyObject Create();
    }
    
    public class MyObjectFactory: IMyObjectFactory
    {
      public int objectId;
      private MyObjectFactory() { }
    
      public static IObjectWithProperty BeginCreation()
      {
        return new MyObjectFactory();
      }
    
      public IObjectWithProperty WithObjectId(int id)
      {
        objectId = id;
        return this;
      }
    
      public MyObject Create()
      {
        return new MyObject(this);
      }
    }
    
    public class MyObject
    {
      public int Id { get; set; }
      public MyObject(IMyObjectFactory factory)
      {
        this.Id = factory.objectId;
      }
    }
