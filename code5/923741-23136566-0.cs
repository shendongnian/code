    public class BaseClass
    {
      protected virtual void OnResultExecuted(ResultExecutedContext resultExecutedContext)
      {
        // Do something like save something to the database
      }
    }
    public class ChildClass : BaseClass
    {
     protected override void OnResultExecuted(ResultExecutedContext resultExecutedContext)
     {
       // Or override the default implementation and do not save it to the database
     }
     protected override void OnResultExecuted(ResultExecutedContext resultExecutedContext)
     {
      // I could either save it to the database
       base.OnResultExecuted(resultExecutedContext);
       // Then do something else after the base implementation OnResultExecuted.
     }
    }
