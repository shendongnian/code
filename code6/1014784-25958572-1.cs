    public interface IService
    {
        // change if you need to return something
        Task DoSomething();
    }
    public Service : IService
    {
        public async Task DoSomething()
        {
            var result = await messageService.ReadMessagesTask();
            if (result == null)
            {
                MessagesList = await messageService.DownloadMessagesTask();
                var writingResult = await messageService.WriteMessagesTask(MessagesList);
            }
        }
    }
