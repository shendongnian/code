    public async void Foo(IProgress<T> progress)
    {
        for(int i = 0; i < MAX_RUNS; i++)
        {
            await Task.Run(() => TimeConsumingMethodCall());
            WhateverYoureDoingWhenEachWorkerCompletes();
            progress.Report(time);
        }
        UpdateUIWithFinalResults();
    }
