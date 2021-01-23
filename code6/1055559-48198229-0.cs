    // ...snip...
    namespace UWPFocusTestApp
    {
        sealed partial class App : Application
        {
            // ...snip...
            protected override void OnLaunched(LaunchActivatedEventArgs e)
            {
                // ...snip...
                if (rootFrame == null)
                {
                    // ...snip...
    
                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
    
                    #region WORKAROUND
                    if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                    {
                        InputPane.GetForCurrentView().Showing += InputPane_Showing;
                    }
                    #endregion
                }
    
                // ...snip...
            }
    
            #region WORKAROUND
            private void InputPane_Showing(InputPane sender, InputPaneVisibilityEventArgs args)
            {
                // we only need to hook once
                InputPane.GetForCurrentView().Showing -= InputPane_Showing;
    
                var frame = (Frame)Window.Current.Content;
    
                // Find root ScrollViewer
                DependencyObject cNode = frame;
                while (true)
                {
                    var parent = VisualTreeHelper.GetParent(cNode);
                    if (parent == null)
                    {
                        break;
                    }
                    cNode = parent;
                }
                var rootScrollViewer = (ScrollViewer)cNode;
    
                // Hook ViewChanged to update scroll offset
                bool hasBeenAdjusted = false;
                rootScrollViewer.ViewChanged += (_1, svargs) =>
                {
                    // once the scroll is removed, clear flag
                    if (rootScrollViewer.VerticalOffset == 0)
                    {
                        hasBeenAdjusted = false;
                        return;
                    }
                    // if we've already adjusted, bail.
                    else if (hasBeenAdjusted)
                    {
                        return;
                    }
    
                    var appBar = ((Page)frame.Content)?.BottomAppBar;
                    if (appBar == null)
                    {
                        return;
                    }
    
                    hasBeenAdjusted = true;
                    rootScrollViewer.ChangeView(null, rootScrollViewer.VerticalOffset + appBar.ActualHeight, null);
                };
            }
            #endregion
    
            // ...snip...
        }
    }
