    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
    {
      foreach(ParagonClass item in args.OldItems)
      {
        // Unsubscribe to changes in each item
        item.PropertyChanged -= OnItemChanged;
      }
      foreach(ParagonClass item in args.NewItems)
      {
        // Subscribe to future changes for each item
        item.PropertyChanged += OnItemChanged;
      }
      Recalculate();
    }
    private void OnItemChanged(object sender, PropertyChangedEventArgs args)
    {
      Recalulate();
      // You might decide that you only want to recalculate for some property 
      // changes, and do something like the following instead
      // if (args.PropertyName=="TotalValue")
      //   Recalulate();
    }
