            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
               BitmapImage bitMapImage = new BitmapImage();
               bitMapImage.SetSource(raStream);
               GameScreen.Source = bitMapImage;
               await raStream.FlushAsync();
            });
