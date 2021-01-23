    private static void UpdateChartingTheme(DependencyObject sender, 
                                            DependencyPropertyChangedEventArgs args)
    {
       if (args.OldValue != null)
       {
           ((INotifyPropertyChanged)args.OldValue).PropertyChanged -= 
                                                 MainWindow_PropertyChanged;
       }
       if (args.NewValue != null)
       {
           ((INotifyPropertyChanged)args.NewValue).PropertyChanged += 
                                                MainWindow_PropertyChanged;
       }
    }
    static void MainWindow_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // Do your work here.
    }
