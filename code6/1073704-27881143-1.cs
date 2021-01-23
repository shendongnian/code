       public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        #region custom app bar
        private Storyboard hideCustomAppBarStoryboard;
        private Storyboard showCustomAppBarStoryboard;
        private Size appBarSize;
        private Size appBarButtonsSize;
        private bool isAppBarShown = true;
        private void CustomAppBarRoot_OnLoaded(object sender, RoutedEventArgs e)
        {
            appBarSize = new Size(CustomAppBarRoot.ActualWidth, CustomAppBarRoot.ActualHeight);
            appBarButtonsSize = new Size(ButtonsStackPanel.ActualWidth, ButtonsStackPanel.ActualHeight);
            InitializeStoryboards();
            HideCustomAppBar();
        }
        private void ShowCustomAppBar()
        {
            isAppBarShown = true;
            showCustomAppBarStoryboard.Begin();
        }
        private void HideCustomAppBar()
        {
            isAppBarShown = false;
            hideCustomAppBarStoryboard.Begin();
        }
        private void DotsTextBlock_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (isAppBarShown)
                HideCustomAppBar();
            else
                ShowCustomAppBar();
        }
        private void InitializeStoryboards()
        {
            hideCustomAppBarStoryboard = new Storyboard();
            showCustomAppBarStoryboard = new Storyboard();
            var showDoubleAnimation = new DoubleAnimation()
            {
                EasingFunction = new CircleEase() {EasingMode = EasingMode.EaseInOut},
                To = 0,
                Duration = new Duration(TimeSpan.FromMilliseconds(200))
            };
            var hideDoubleAnimation = new DoubleAnimation()
            {
                EasingFunction = new CubicEase() {EasingMode = EasingMode.EaseInOut},
                To = appBarButtonsSize.Height,
                Duration = new Duration(TimeSpan.FromMilliseconds(200))
            };
            hideCustomAppBarStoryboard.Children.Add(hideDoubleAnimation);
            showCustomAppBarStoryboard.Children.Add(showDoubleAnimation);
            Storyboard.SetTarget(hideCustomAppBarStoryboard, CustomAppBarRoot);
            Storyboard.SetTarget(showCustomAppBarStoryboard, CustomAppBarRoot);
            Storyboard.SetTargetProperty(showCustomAppBarStoryboard, "(UIElement.RenderTransform).(TranslateTransform.Y)");
            Storyboard.SetTargetProperty(hideCustomAppBarStoryboard, "(UIElement.RenderTransform).(TranslateTransform.Y)");
        }
        #endregion
        private void CustomAppBarRoot_OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var translateTransform = (CustomAppBarRoot.RenderTransform as TranslateTransform);
            double newY = e.Delta.Translation.Y + translateTransform.Y;
            translateTransform.Y = Math.Max(0, Math.Min(newY, appBarButtonsSize.Height));
        }
        private void CustomAppBarRoot_OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (!isAppBarShown)
                ShowCustomAppBar();
            else
                HideCustomAppBar();
        }
    }
