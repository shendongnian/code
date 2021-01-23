    private async Task GenerateMapParallel(Canvas cMap)
    {
        cMap.Children.Clear();
        var task1 = Task.Factory.StartNew(() => Generate(0, 330, cMap));
        var task2 = Task.Factory.StartNew(() => Generate(331, 660, cMap));
        await Task.WhenAll(task1, task2);
    }
