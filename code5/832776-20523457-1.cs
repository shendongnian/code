    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new CommandFactory();
    
            var cmd = factory.Create<DeleteUserCommand>(new object[] { 23 });
    
            cmd.Execute();
        }
    }
