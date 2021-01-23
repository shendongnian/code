           public void Subscribe()
           {
             IRiskEoDWCFEvents callback = OperationContext.Current.GetCallbackChannel<IRiskEoDWCFEvents>();
             call = callback;
             lock (_SubscriberLock)
             {
                 if (!_EoDEventSubscribers.Contains(callback))
                 {
                     Logging.WriteLine("Adding callback {0}", callback.GetHashCode());
                     _EoDEventSubscribers.Add(callback);
                }
            }
        }
