    var vm = DataContext as SomeViewModel; //Get VM from view's DataContext
    if (vm == null) return; //Check if conversion succeeded
    vm.DoSomethingNotice += DoSomething; // Subscribe to event
    private void DoSomething(object sender, NotificationEventArgs<string> e)
    {
        // Code    
    }
