      private void Page_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            switch (ApplicationView.Value)
            {
                case ApplicationViewState.FullScreenLandscape:
                    VisualStateManager.GoToState(this, "FullScreenLandscape", false);
                    Snapped.Visibility = Visibility.Collapsed;
                    break;
                case ApplicationViewState.Snapped:
                    VisualStateManager.GoToState(this, "Snapped", false);
                    FullScreenLandscape.Visibility = Visibility.Collapsed;
                    Snapped.Visibility = Visibility.Visible;
                    break;
                default:
                    return;
            }
        }
