    Task<IEnumerable<int>> resultTask = new Task<IEnumerable<int>>(() =>
    {
        for (int i = 0; i < 10; ++i)
        {
            yield return i;
        }
    });
