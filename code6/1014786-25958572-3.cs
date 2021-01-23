    public interface IService
    {
        // change if you need to return something
        Task DoSomething();
    }
    public Service : IService
    {
        public async Task DoSomething()
        {
            var result = await ReadMessagesTask();
            if (result == null)
            {
                var messages = await DownloadMessagesTask();
                await WriteMessagesTask(messages);
            }
        }
        // private read/download methods here...
    }
