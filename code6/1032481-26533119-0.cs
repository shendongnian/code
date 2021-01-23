      protected static void OnMyCollectionItemsSourceChanged(DependencyObject property, DependencyPropertyChangedEventArgs args)
        {
            if( args.OldValue is INotifyCollectionChanged)
               (args.OldValue as INotifyCollectionChanged ).CollectionChanged -= CollectionChangedHandler;
           if(args.NewValue is INotifyCollectionChanged)
               (args.OldValue as INotifyCollectionChanged).CollectionChanged += CollectionChangedHandler;
    
        }
    
        private static void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
          //
        }
