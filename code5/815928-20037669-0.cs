    private double _scrollingFrom;
    ScrollViewer.Loaded += (sender, args) => VisualStateHelper.HookEvent<ScrollViewer>(ScrollViewer, "ScrollStates", scrollHandler);
    
    private void scrollHandler(object sender, VisualStateChangedEventArgs e) {
        if (e.NewState.Name.Equals("NotScrolling")) {
            if (ScrollViewer.VerticalOffset < _scrollingFrom) {
                // Scrolled up
            } else {
                // Scrolled down
            }
        } else {
            _scrollingFrom = ScrollViewer.VerticalOffset;
        }
    }
