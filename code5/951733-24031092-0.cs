    private async void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (e.IsIntermediate)
            {
                this.BottomAppBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
                this.BottomAppBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
