    static async Task ChkRequestTask(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine("Checking the card");
            var status = PollTheCardForStatus();
            if(!status)
                break;
            await Task.Delay(15 * 1000, token);//Adjust the delay as you wish
        }
    }
