        private async static Task<string> GetPin()
        {
            var taskCompletionSource = new TaskCompletionSource<string>();
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            async () =>
            {
                var pin = await UI.GetPin();
                taskCompletionSource.SetResult(pin);
            }
            ).AsTask();
            return await taskCompletionSource.Task;
        }
