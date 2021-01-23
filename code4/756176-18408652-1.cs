            if ( _EoDEventSubscribers == null || _EoDEventSubscribers.Count == 0)
            {
                //Cannot publish because we have no one listening
                return;
            }
            if (call == null)
            {
                try
                {
                    call = OperationContext.Current.GetCallbackChannel<IRiskEoDWCFEvents>();
                }
                catch
                {
                    call = _EoDEventSubscribers[0];
                }
            }
