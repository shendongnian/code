    List<ConsoleKeyInfo> keyBuffer = new List<ConsoleKeyInfo>();
    new Thread(() =>
    {
        while(true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (keyBuffer.Count > 0)
                {
                    if (keyBuffer[keyBuffer.Count - 1] != key)
                        keyBuffer.Add(key);
                }
                else
                    keyBuffer.Add(key);
            }
            Thread.Sleep(1);
        }
    }).Start();
    while(true)
    {
        if (keyBuffer.Count>0)
        {
            switch (keyBuffer[0].Key)
            {
                //SwitchSomeStuff
            }
            keyBuffer.RemoveAt(0);
        }
        //PlayGame
    }
