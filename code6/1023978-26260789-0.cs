    private int WhosTurn()
    {
        // Create cancellation token. Will be used to inform other threads that they should immediately cancel processing
        CancellationTokenSource cts = new CancellationTokenSource();
        // Collection of tasks that run in parallel
        List<Task<int>> tasks = new List<Task<int>>()
        {
            Task.Run<int>(() => {
                return BattleHeroTurn1(cts.Token) ? 1 : 0; 
            }),
            Task.Run<int>(() => {
                return BattleHeroTurn2(cts.Token) ? 2 : 0;
            }),
            Task.Run<int>(() => {
                return BattleHeroTurn3(cts.Token) ? 3 : 0;
            })
        };
        // Wait for any task to complete and if it is successful, cancel the other tasks and return
        while (tasks.Any())
        {
            // Get the index of the task that completed
            int completedTaskIndex = Task.WaitAny(tasks.ToArray());
            int turn = tasks[completedTaskIndex].Result;
            if(turn > 0)
            {
                cts.Cancel();
                return turn;
            }
            tasks.RemoveAt(completedTaskIndex);
        }
        // All tasks have completed but no BattleHeroTurnX returned true
        return 0;
    }
    static bool BattleHeroTurn1(CancellationToken token)
    {
        // Processing images. After each one is processed, ensure that the token has not been canceled
        for(int i = 0; i < 100; i++)
        {
            Thread.Sleep(50);
            if (token.IsCancellationRequested)
            {
                return false;
            }
        }
        return true;
    }
    static bool BattleHeroTurn2(CancellationToken token)
    {
        // Processing images. After each one is processed, ensure that the token has not been canceled
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(70);
            if (token.IsCancellationRequested)
            {
                return false;
            }
        }
        return true;
    }
    static bool BattleHeroTurn3(CancellationToken token)
    {
        // Processing images. After each one is processed, ensure that the token has not been canceled
        for (int i = 0; i < 1000; i++)
        {
            Thread.Sleep(500);
            if (token.IsCancellationRequested)
            {
                return false;
            }
        }
        return true;
    }
