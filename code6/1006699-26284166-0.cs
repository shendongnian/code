    public class MainPage:Page
    {
        public MainPage()
        {
            this.Loaded += page_Loaded;
            this.Unloaded += page_Unloaded;
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += Window_SizeChanged;
        }
        private void page_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Window_SizeChanged;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpdateVisualState();
        }
        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            UpdateVisualState();
        }
        private void UpdateVisualState()
        {
            var visualState = string.Empty;
            var applicationView = ApplicationView.GetForCurrentView();
            if (applicationView.IsFullScreen)
            {
                if (applicationView.Orientation == ApplicationViewOrientation.Landscape)
                    visualState = "FullScreenLandscape";
                else
                    visualState = "FullScreenPortrait";
            }
            else
            {
                var size = Window.Current.Bounds;
                if (size.Width == 320)
                    visualState = "Snapped";
                else if (size.Width <= 500)
                    visualState = "Narrow";
                else
                    visualState = "Filled";
            }
            VisualStateManager.GoToState(this, visualState, true);
        }
    }
