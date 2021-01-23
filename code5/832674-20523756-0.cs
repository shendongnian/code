    public void LockAndDoInBackground(Action action, string text, Action beforeVisualAction = null, Action afterVisualAction = null)
        {
            var currentSyncContext = SynchronizationContext.Current;
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (_, __) =>
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                currentSyncContext.Send((t) =>
                {
                    IsBusy = true;
                    BusyText = string.IsNullOrEmpty(text) ? "Espere por favor..." : text;
                    if (beforeVisualAction != null)
                        beforeVisualAction();
                }, null);
                action();
                currentSyncContext.Send((t) =>
                {
                    IsBusy = false;
                    BusyText = "";
                    if (afterVisualAction != null)
                        afterVisualAction();
                }, null);
            };
            backgroundWorker.RunWorkerAsync();
        }
