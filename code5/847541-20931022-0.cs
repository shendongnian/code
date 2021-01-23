    static async Task Foo(IProgress<int> onProgressPercentChanged)
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i % 100 == 0)
                {
                    onProgressPercentChanged.Report(i / 100);
                }
            }
        });
    }
