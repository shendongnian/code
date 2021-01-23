	 public class WeakEvent2<TDelegate> where TDelegate : class
	 {
		
			private TDelegate _invocationList;
		
			 public TDelegate Invoke
			{
				get { return _invocationList;    }
			}
			
			
			public void Subscribe(TDelegate handler)
			{
				lock (this)
					_invocationList = Delegate.Combine(_invocationList as Delegate, new WeakEventHandler2(handler, weh=> Unsubscribe(weh) )) as TDelegate;
			}
			
			...
			...
	}
	
