    public class SimplyAwesome : IAmAwesome 
    {
        public Task MakeAwesomeAsync() 
        {
            // run synchronously
            return TaskExtensions.CompletedTask;
        }
    }
