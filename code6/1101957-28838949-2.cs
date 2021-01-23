    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);
        downloadString.Post("http://www.google.com");
        
        if (printPalindrome.Completion.IsCompleted)
        {
            break;
        }
        
        Task.WhenAny(semaphore.WaitAsync(), printPalindrome.Completion).Wait();
    }
