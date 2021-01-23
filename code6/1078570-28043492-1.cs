    public static async Task CreateInstance(bool local)
    {
        var model = new DecksViewModel();
        if (local)
        {
            await InitializeLocalDeckList();
        }
        else
        {
            await Dereffering();
        }
    }
    
