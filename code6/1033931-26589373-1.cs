        public async Task<string> GetServerTime(IProgress<int> prog)
       {
        await Task.Run(() => {
            for (int i = 0; i < 10; i++)
            {
                prog.Report(i * 10);
                // Call to your client side method.
                Clients.Client(Context.ConnectionId).progress(i);
                System.Threading.Thread.Sleep(200);
            }
        });
        return DateTime.Now.ToString();
    }
