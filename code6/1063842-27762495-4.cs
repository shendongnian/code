    public class EventBroadcaster
    {
        public event EventHandler SomeEventOccured;
        public async void DoLongRunningOperationAndRaiseFinishedEvent()
        {
            var waitingTask = Task.Delay(TimeSpan.FromSeconds(2));
            await waitingTask.ContinueWith(t => RaiseSomeEventOccured(), CancellationToken.None,
                TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Current);
        }
        private void RaiseSomeEventOccured()
        {
            EventHandler handler = SomeEventOccured;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
