    public interface IService
    {
        // change if you need to return something
        Task DoSomething();
    }
    public Service : IService
    {
        public async Task DoSomething()
        {
            var result = await ReadMessagesAsync();
            if (result == null)
            {
                var messages = await DownloadMessagesAsync();
                await WriteMessagesAsync(messages);
            }
        }
        // private read/download methods here...
    }
