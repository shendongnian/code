    public interface ICommand
    {
        void Execute();
    }
    
    public class CreateUserCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Hello World");
        }
    }
    
    public class DeleteUserCommand : ICommand
    {
        private readonly int _userId;
    
        public DeleteUserCommand(int userId)
        {
            _userId = userId;
        }
    
        public void Execute()
        {
            Console.WriteLine("Deleting " + _userId);
        }
    }
    
    public interface ICommandFactory
    {
        ICommand Create<T>();
    }
    
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create<T>()
        {
            return Activator.CreateInstance<T>() as ICommand;
        }
    
        public ICommand Create<T>(object[] args)
        {
            return Activator.CreateInstance(typeof(T), args) as ICommand;
        }
    }
