    public void Hide()
        {
            UnityApp.Obscure(false);
            UnityApp.Deactivate();
            MainPage.Instance.Dispatcher.BeginInvoke(() =>
            {
                MainPage.Instance.DrawingSurfaceBackground.SetBackgroundContentProvider(null);
                MainPage.Instance.DrawingSurfaceBackground.SetBackgroundManipulationHandler(null);
                MainPage.Instance.HideUnityBorder.Visibility = Visibility.Visible;
                MainPage.Instance.ApplicationBar.IsVisible = true;
            });
        }
        public void Show()
        {
            var content = Application.Current.Host.Content;
            var width = (int)Math.Floor(content.ActualWidth * content.ScaleFactor / 100.0 + 0.5);
            var height = (int)Math.Floor(content.ActualHeight * content.ScaleFactor / 100.0 + 0.5);
            UnityApp.SetNativeResolution(width, height);
            UnityApp.UnObscure();
            MainPage.Instance.Dispatcher.BeginInvoke(() =>
            {
                MainPage.Instance.DrawingSurfaceBackground.SetBackgroundContentProvider(UnityApp.GetBackgroundContentProvider());
                MainPage.Instance.DrawingSurfaceBackground.SetBackgroundManipulationHandler(UnityApp.GetManipulationHandler());
                MainPage.Instance.HideUnityBorder.Visibility = Visibility.Collapsed;
                MainPage.Instance.ApplicationBar.IsVisible = false;
            });
        }
