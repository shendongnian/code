        void PerformOperations();
    }
    public class EasyOperations : IOperations
    {
       public void PerformOperations()
        {
            Console.WriteLine("Do easy operations here");
        }
    }
    public class ComplexOperations : IOperations
    {
        public void PerformOperations()
        {
            Console.WriteLine("Do complex operations here");
        }
    }
    public interface ICommand
    {
        void Execute();
    }
    public class EasyCommand : ICommand
    {
        IOperations opn;
        public EasyCommand(IOperations opn)
        {
            this.opn=opn;
        }
        public void Execute()
        {
            opn.PerformOperations();
        }
    }
     public class ComplexCommand : ICommand
    {
        IOperations opn;
        public ComplexCommand(IOperations opn)
        {
            this.opn=opn;
        }
        public void Execute()
        {
            opn.PerformOperations();
        }
    }   
    public class OperationsPerformer
    {
        IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        public OperationsPerformer()
        {
            commands.Add("easy", new EasyCommand(new EasyOperations()));
            commands.Add("complex",new ComplexCommand(new ComplexOperations()));
        }
        public void perform(string key)
        {
            if (commands[key] != null)
            {
                ICommand command = commands[key];
                command.Execute();
            }            
        }
    }
    public class Client
    {
        public static void Main(String[] args)
        {
            OperationsPerformer performer = new OperationsPerformer();
            performer.perform("easy");
            performer.perform("complex");
            Console.ReadKey();
        }
    }
