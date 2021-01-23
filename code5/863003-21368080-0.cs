    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            Task todo = asyncMethod();
            todo.ContinueWith((str) =>
            {
                Console.WriteLine(str.Status.ToString());
                Console.WriteLine("Main end");
            });
            todo.Wait();
        }
        public async static Task<string> asyncMethod()
        {
            MobileServiceClient MobileService = new MobileServiceClient(
            "mymobileservice url",
            "my application ID"
            );
            todoTable = MobileService.GetTable<TodoItem>();
            await todoTable.InsertAsync(new TodoItem() { Text = "Console Item 2", Complete = false });
            return "finished";
        }
    }
