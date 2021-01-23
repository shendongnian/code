    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        // TODO: Save application state and stop any background activity
        Debug.WriteLine("SUSPENDING");
        // Wait fir Save to finish its a sync operations
        await HabitManager.HabitSerializer.Save();
        deferral.Complete();
    }
    public async static Task Save()
    {
        // Same save code
    }
