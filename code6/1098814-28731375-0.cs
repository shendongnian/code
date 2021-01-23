    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
            InputPane.GetForCurrentView().Showing += onKeyboardShowing;
            InputPane.GetForCurrentView().Hiding += onKeyboardHidding;
    }
    private void onKeyboardShowing(InputPane sender, InputPaneVisibilityEventArgs args)
    {
        KeyboardVisible = true;
    }
    private void onKeyboardHidding(InputPane sender, InputPaneVisibilityEventArgs args)
    {
            
        KeyboardVisible = false;
    }
