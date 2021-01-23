    public void SaveSome()
    {
        Action<int> action = SaveRepAsync;
        Array.ForEach(Enumerable.Range(0,3).ToArray(), action);
    }
    private static async void SaveRepAsync(int x)
    {
        await SaveRep();
    }
