    private void ObservableCollection_OnCollectionChanged2(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
        using(var guard = new Guard(() => BindingTargetUpdating, v => BindingTargetUpdating = value))
        {
           if (guard.Acquired)
           {
               // Do change logic and update Custom Object....
           }
        }
    }
