    public class Guard
    {
      public Guard([CallerMemberName] string callerName = null)
      {
        var constructorExpression = (Expression<Func<Prohibited>>)(() => new Prohibited());
        var constructorMethod = (NewExpression) (constructorExpression.Body);
        var stackFrames = new StackTrace().GetFrames();
        if (stackFrames.Any(f => f.GetMethod() == constructorMethod.Constructor))
        {
          throw new InvalidOperationException("Aha! you are still trying.");
        }
      }
    }
    public partial class Prohibited : DbContext
    {
       public Prohibited()
                : base("wrong connection string")
       {
       }
    }
    public partial class Prohibited 
    {
      private Guard guard = new Guard();
      public Prohibited(string connectionString)
                : base(connectionString)
      {
      }
    }
