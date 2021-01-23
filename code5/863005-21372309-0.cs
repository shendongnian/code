    class Program
    {
        static IMobileServiceTable<TodoItem> todoTable;
        static void Main(string[] args)
        {
            MobileServiceClient MobileService = new MobileServiceClient(
                "mymobileservice url",
                "my application ID"
            );
            todoTable = MobileService.GetTable<TodoItem>();
            var item = new TodoItem() { Text = "Console Item 2", Complete = false };
            todoTable.InsertAsync(item).Wait();
            var itemId = item.Id;
            var retrieved = todoTable.LookupAsync(itemId).Result;
            //Console.ReadLine();
        }        
    }
