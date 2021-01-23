    public static async void ErrorHandle(this Task task, Action action = null)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Log.Error(e);
            if (action != null)
                action();
        }
    }
