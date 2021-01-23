     private async void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (e.IsIntermediate==false && scrollViewer.VerticalOffset >= canContentContaner.ActualHeight - scrollViewer.ActualHeight)
            {
               //You have reached at the end of scroll...
            }
        }
