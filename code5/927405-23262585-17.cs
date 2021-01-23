    for (int i = 1; i <= totalCalls; i++)
    {
        var t = new Task(GoogleSearch, i);
        t.Start();
    }
    // ...
    private static async void GoogleSearch(object searchTerm)
    {
        // ...
    }
