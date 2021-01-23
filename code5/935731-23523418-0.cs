    public void LockAndDoInBackground(Action action, string text, Action beforeVisualAction = null, Action afterVisualAction = null)
    {
        if (IsBusy)
            return;
        var currentSyncContext = SynchronizationContext.Current;
        ActiveThread = new Thread((_) =>
        {                
            currentSyncContext.Send(t =>
            {
                IsBusy = true;
                BusyText = string.IsNullOrEmpty(text) ? "Wait please..." : text;
                if (beforeVisualAction != null)
                    beforeVisualAction();
            }, null);
            action();
            currentSyncContext.Send(t =>
            {
                IsBusy = false;
                BusyText = "";
                if (afterVisualAction != null)
                    afterVisualAction();
            }, null);
        });
        ActiveThread.Start();
    }
