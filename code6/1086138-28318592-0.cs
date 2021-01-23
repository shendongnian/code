    //create a queue to store event args
    var deferredEventArgs = new Queue<RoutedEventArgs>();
    //temporarily assign a handler/command that will store the args in the queue
    ListLoaded = new RelayCommand<RoutedEventArgs>(e => deferredEventArgs.Enqueue(e));
    Task tskOpen = Task.Factory.StartNew(() =>
    {
        ProgressBarVisibility = Visibility.Visible;
        DataAccess data = new DataAccess();
        DoctorDetailsBooking = data.GetDoctorsList(Convert.ToDateTime(BookingDate).Date);
        FillSlots();
        
        //assign the proper handler/command once its ready
        ListLoaded = new RelayCommand<RoutedEventArgs>(ListViewLoaded);
        
    }).ContinueWith(t =>
    {
        //"flush" the queue - handle previous events
        //decide whether it should be done on the UI thread
        while(deferredEventArgs.Any())
            ListViewLoaded(deferredEventArgs.Dequeue());
        ProgressBarVisibility = Visibility.Hidden;
    }, TaskScheduler.FromCurrentSynchronizationContext());
