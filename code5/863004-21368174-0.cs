    class Program
    {
      static IMobileServiceTable<TodoItem> todoTable;
      static void Main(string[] args)
      {
        MainAsync(args).Wait();
      }
      static async Task MainAsync(string[] args)
      {
        try
        {
          MobileServiceClient MobileService = new MobileServiceClient(
            "mymobileservice url",
            "my application ID"
          );
          todoTable = MobileService.GetTable<TodoItem>();
          await todoTable.InsertAsync(new TodoItem() { Text = "Console Item 2", Complete = false });
        }        
        catch (Exception ex)
        {
          ...
        }
      }
    }
