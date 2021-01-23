    await Task.Delay(1000).ContinueWith(
        task => 
            {
                if (!task.IsFaulted) {
                    return;
                }
    
                Console.WriteLine("{0}", task.Exception);
                // do smth like 'throw task.Exception.InnerException'
            });
