    class MarshaledObservableCollection<T> : IEnumerable<T>, INotifyCollectionChanged, IWeakEventListener {
        readonly IEnumerable<T> backingCollection;
    
        public event NotifyCollectionChangedEventHandler CollectionChanged {
    		add {
    	    		var info = new NotifyCollectionChangedEventHandlerInfo {
    				Handler = value,
    				Dispatcher = Dispatcher.CurrentDispatcher,
    			};
    			collectionChangedHandlers.Add(info);
    		}
    		remove {
    			var info = new NotifyCollectionChangedEventHandlerInfo {
    				Handler = value,
    				Dispatcher = Dispatcher.CurrentDispatcher,
    			};
    			collectionChangedHandlers.Remove(info);
    		}
    	}
    
    	readonly List<NotifyCollectionChangedEventHandlerInfo> collectionChangedHandlers = new List<NotifyCollectionChangedEventHandlerInfo>();
    
    	public MarshaledObservableCollection(IEnumerable<T> collection) {
    		if (collection == null)
    			throw new ArgumentNullException("collection", "collection is null.");
    
    		var obs = collection as INotifyCollectionChanged;
    		if (obs == null)
    			throw new ArgumentException("collection must be INotifyCollectionChanged", "collection");
    
    		backingCollection = collection;
    		CollectionChangedEventManager.AddListener(obs, this);
    	}
    
    	public IEnumerator<T> GetEnumerator() {
    		return backingCollection.GetEnumerator();
    	}
    
    	protected virtual void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
    		foreach (var item in collectionChangedHandlers) {
    			//Important line - invoking asynchronously with the DataBind priority
    			item.Dispatcher.BeginInvoke(item.Handler, DispatcherPriority.DataBind, sender, e);
    		}
    	}
    
    	public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e) {
    		if (managerType == typeof(CollectionChangedEventManager)) {
    			OnCollectionChanged(sender, (NotifyCollectionChangedEventArgs)e);
    			return true;
    		} else {
    			return false;
    		}
    	}
    
    	IEnumerator IEnumerable.GetEnumerator() {
    		return GetEnumerator();
    	}
    
    	struct NotifyCollectionChangedEventHandlerInfo {
    		public Dispatcher Dispatcher { get; set; }
    		public NotifyCollectionChangedEventHandler Handler { get; set; }
    	}
    }
