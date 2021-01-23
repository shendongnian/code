        public object AutoScrollTrigger 
        {
            get { return (object)GetValue( AutoScrollTriggerProperty ); }
            set { SetValue( AutoScrollTriggerProperty, value ); }
        }
        public static readonly DependencyProperty AutoScrollTriggerProperty = 
            DependencyProperty.Register(  
                "AutoScrollTrigger", 
                typeof( object ), 
                typeof( TouchScroller ), 
                new PropertyMetadata( null, ASTPropertyChanged ) );
        IDisposable col;
        private static void ASTPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs args )
        {
            var ts = d as TouchScroller;            
            if( ts == null )
                return;
            var sv = ts.AssociatedObject as ScrollViewer;
            
            // check if we are attached to an ObservableCollection, in which case we
            // will subscribe to CollectionChanged so that we scroll when stuff is added/removed
            var ncol = args.NewValue as INotifyCollectionChanged;
            
            if( ncol != null )
            {
                // clean up previous subscription, if any
                if( ts.col != null )
                    ts.col.Dispose();
                
                // new subscription
                ts.col = ncol.OnCollectionChanged()
                    .ObserveOnDispatcher()
                    .Subscribe( ep =>
                        {
                            if( sv != null & ts.AutoScroll )
                                sv.ScrollToBottom();
                        } );
            }
            
            // also scroll to bottom when the bound object itself changes
            if( sv != null && ts.AutoScroll )
                sv.ScrollToBottom();
        }
