    internal static async Task HandledAction(Func<Task> action, Info infoBar)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            infoBar.SetError("An Exception occured: " + ex.Message);
            WriteLog(ex.StackTrace);
        }
    }
