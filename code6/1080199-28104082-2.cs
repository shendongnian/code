    public async void YourMethodName() 
    {
        await Task.Run(() => 
            {
                    while (true)
                    {
                        if (!fc.SecondString.Equals(AnotherPartyLibrary.firstString))
                        {
                            fc.SecondString = AnotherPartyLibrary.firstString;
                        }
                        Thread.Sleep(1000);
                    }
            });
    }
