    public class MyObjectFactory: IMyObjectFactory
    {
      private int objectId;
      private MyObjectFactory() { }
		
      public static IObjectWithProperty BeginCreation()
      {
        return new ObjectFactory();
      }
		
      public IObjectWithProperty WithObjectId(int id)
      {
        objectId = id;
        return this;
      }
      public MyObject Create()
      {
        return new MyObject(objectId);
      }
    }
    public class MyObject
    {
      public int Id { get; set; }
      public MyObject(int objectId)
      {
        this.Id = objectId;
      }
    }
