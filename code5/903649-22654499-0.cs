    var period = TimeSpan.FromMilliseconds(10);
            Windows.System.Threading.ThreadPoolTimer.CreateTimer(async (source) =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    var Succes = MainPhotoDisplayscrollViewer.ChangeView(null, null, 1.0F, false);
                });
            }, period);
