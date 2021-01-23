    public string Distance
    {
        get
        {
            return Dispatcher.Invoke(() => cbo_DistanceMeasure.SelectedValue.ToString(), DispatcherPriority.Background);
        }
    }
    
