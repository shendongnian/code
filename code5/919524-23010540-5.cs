      private void Page_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            if (Windows.UI.ViewManagement.ApplicationView.Value == Windows.UI.ViewManagement.ApplicationViewState.FullScreenLandscape)
            {              
                landscape.Visibility = Windows.UI.Xaml.Visibility.Visible;
                snap.Visibility = Windows.UI.Xaml.Visibility.Collapsed;                     
                t1.SetValue(Grid.ColumnProperty, 0);
                t2.SetValue(Grid.ColumnProperty, 1);
                if (t1.Parent != landscape)
                {
                    snap.Children.Remove(t1);
                    snap.Children.Remove(t2);
                    landscape.Children.Add(t1);
                    landscape.Children.Add(t2);
                }
                                 
            }
            else if(Windows.UI.ViewManagement.ApplicationView.Value == Windows.UI.ViewManagement.ApplicationViewState.Snapped)
            {
                landscape.Children.Remove(t1);
                landscape.Children.Remove(t2);
                landscape.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                snap.Visibility = Windows.UI.Xaml.Visibility.Visible;
                t1.SetValue(Grid.RowProperty, 0);
                t2.SetValue(Grid.RowProperty, 1);
                if (t1.Parent != snap)
                {
                    landscape.Children.Remove(t1);
                    landscape.Children.Remove(t2);
                    snap.Children.Add(t1);
                    snap.Children.Add(t2);
                  
                }                                
            }
        }
