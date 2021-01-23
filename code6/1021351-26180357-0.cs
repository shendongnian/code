    public class MyViewModel
    {
      public MyViewModel()
      {
        Mail = new NotifyTaskCompletion<Group>(CreateMailAsync());
      }
      public NotifyTaskCompletion<Group> Mail { get; private set; }
      private async Task<Group> CreateMailAsync()
      {
        // Azure calls go here
      }
    }
