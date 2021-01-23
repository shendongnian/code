    public partial class App
    {
      private readonly Task _initializingTask;
      public App()
      {
        _initializingTask = Init();
      }
      private async Task Init()
      {
        /*
        Initialization that you need with await/async stuff allowed
        */
        string result = await RequestDataTask();
      }
    }
