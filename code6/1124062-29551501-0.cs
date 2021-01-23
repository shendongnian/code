    ObservableCollection<Process> processes = new ObservableCollection<Process>();
    processes.CollectionChanged += processes_CollectionChanged;
    static void processes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
            foreach (var process in e.NewItems.OfType<Process>())
                process.Kill();
        processes.Clear();//remove all Processes from the list
    }
