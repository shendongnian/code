        [UIPermissionAttribute(SecurityAction.LinkDemand,Unrestricted=true)]
        [SecurityCritical]
        public static void PushFrame(DispatcherFrame frame)
        {
            if(frame == null)
            {
                throw new ArgumentNullException("frame");
            }
 
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            if(dispatcher._hasShutdownFinished) // Dispatcher thread - no lock needed for read
            {
                throw new InvalidOperationException(SR.Get(SRID.DispatcherHasShutdown));
            }
 
            if(frame.Dispatcher != dispatcher)
            {
                throw new InvalidOperationException(SR.Get(SRID.MismatchedDispatchers));
            }
            //here
            if(dispatcher._disableProcessingCount > 0) 
            {
                throw new InvalidOperationException(SR.Get(SRID.DispatcherProcessingDisabled));
            }
 
            dispatcher.PushFrameImpl(frame);
        }
