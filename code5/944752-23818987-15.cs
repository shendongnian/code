    public class FakeEmptyDatabaseRepository:IDataRepository
    {
      public CommandMessages DequeueTestProject(){CallCount++;return null;}
      //CallCount tracks if the method was invoked.
      public int CallCount{get;private set;}
    }
    public class FakeFilledDatabaseRepository:IDataRepository
    {
      public CommandMessages DequeueTestProject(){CallCount++;return new CommandMessages("","","");}
      public int CallCount{get;private set;}
    }
