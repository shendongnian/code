    public static class ClientOutput
    {
        public static Task Execute(Action action)
        {
            return Task.Run(action);
        }
    }
