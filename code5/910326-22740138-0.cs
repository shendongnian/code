     private async void MainPagePanorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    selectedItem = MainPagePanorama.SelectedItem as PanoramaItem;
                    await Task.Run(() =>
                    {
                       Thread.Sleep(100);
                       TitleColor.Color = (selectedItem.Foreground as SolidColorBrush).Color;
                    });
                }
