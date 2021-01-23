    // where 
    ObservableCollection<Foo> foo = new();
    element.ItemsSource = foo;
    // then negotiate to non-generic types
    var bar = element.ItemsSource as INotifyCollectionChanged;
    bar.CollectionChanged += (NotifyCollectionChangedEventHandler)(delegate(object sender, NotifyCollectionChangedEventArgs e) 
    {
      var collection = bar as ICollection;
      // TODO: handle based on collection.Count
    });
