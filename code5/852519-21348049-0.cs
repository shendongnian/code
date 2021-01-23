    public sealed class TileUpdater : IBackgroundTask
    {    
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get a deferral, to prevent the task from closing prematurely 
            // while asynchronous code is still running.
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            // Update the live tile with the names.
            UpdateTile(await GetText());
            // Inform the system that the task is finished.
            deferral.Complete();
        }
        public async static void RunTileUpdater()
        {
            UpdateTile(await GetText());
        }
    }
