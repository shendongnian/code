        private void ChangeColor_OnClick(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            this.Background = new SolidColorBrush(new Color { A = 255, R = (byte)rand.Next(1, 255), G = (byte)rand.Next(1, 255), B = (byte)rand.Next(1, 255) });
        }
        private async void TakeScreenshot_OnClick(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap();
            await rtb.RenderAsync(this as FrameworkElement);
            this.DisplayedScreenshot.Source = rtb;
        }
        private async void TakeScreenshotOfSelected_OnClick(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap();
            await rtb.RenderAsync(this.ListBox.SelectedItem as UIElement);
            this.DisplayedScreenshot.Source = rtb;
        }
