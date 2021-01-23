    System.Windows.Application.Current.Dispatcher.Invoke(
        System.Windows.Threading.DispatcherPriority.Normal,
        (System.Action)delegate()
        {
             tempPropertyGrid.SelectedObject = new object();
        });
