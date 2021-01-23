    public class BaseObservableCollection<T> : ObservableCollection<T>
    {
      // Constructors
      public BaseObservableCollection() : base() { }
      public BaseObservableCollection(IEnumerable<T> items) : base(items) { }
      public BaseObservableCollection(List<T> items) : base(items) { }
      // Evnet
      public override event NotifyCollectionChangedEventHandler CollectionChanged;
      // Event Handler
      protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
      {
        // Be nice - use BlockReentrancy like MSDN said
        using (BlockReentrancy())
        {
          if (CollectionChanged != null)
          {
            // Walk thru invocation list
            foreach (NotifyCollectionChangedEventHandler handler in CollectionChanged.GetInvocationList())
            {
              DispatcherObject dispatcherObject = handler.Target as DispatcherObject;
              // If the subscriber is a DispatcherObject and different thread
              if (dispatcherObject != null && dispatcherObject.CheckAccess() == false)
              {
                // Invoke handler in the target dispatcher's thread
                dispatcherObject.Dispatcher.Invoke(DispatcherPriority.DataBind, handler, this, e);
              }
              else
              {
                // Execute handler as is
                handler(this, e);
              }
            }
          }
        }
      }
    }
