    public class ClientOutput
    {
        public Task Execute(Action action)
        {
            return Task.Run(action);
        }
    }
