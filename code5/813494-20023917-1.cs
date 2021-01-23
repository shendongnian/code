    public class CommandProcessor : ICommandProcessor
    {
        public void Process(Command command)
        {
            using (var transaction = new TransactionScope())
            {
                var handler = LookupHandler(command);
                handler.Handle(command);
    
                transaction.Complete();
            }
        }
    }
