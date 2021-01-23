    private void SomeMethodWithRecursiveLoop()
    {
        StopFiringPropertyChanged = true;
        try
        {
             // do the work
        }
        finally
        {
            StopFiringPropertyChanged = false;
            OnPropertyChanged("SomeProperty1");
            OnPropertyChanged("SomeProperty2");
            OnPropertyChanged("SomeProperty3");
        }   
    }
