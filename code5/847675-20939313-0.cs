       var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
            var period = TimeSpan.FromSeconds(30);
            var timer = ThreadPoolTimer.CreatePeriodicTimer( async (source) =>
             {
                await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                 {
                     RefreshOrdersList();
                 });
             }, period);
