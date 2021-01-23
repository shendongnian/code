    if (App.HasDashboardRole)
                {
                    App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        var bs = new BBCodeBlock();
                        bs.LinkNavigator.Navigate(new Uri("/Pages/Dashboard.xaml", UriKind.Relative), this);
                    }));
                }
                else if (App.HasBarcodeBuilderRole)
                {
                    App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        var bs = new BBCodeBlock();
                        bs.LinkNavigator.Navigate(new Uri("/Pages/BarcodeBuilderPage.xaml", UriKind.Relative), this);
                    }));
                }
