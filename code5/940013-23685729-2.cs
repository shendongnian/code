        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.FieldLayoutInitialized += OnFieldLayoutInitialized;            
            this.AssociatedObject.RecordExpanded += OnRecordExpanded;
        }
        void OnRecordExpanded(object sender, Infragistics.Windows.DataPresenter.Events.RecordExpandedEventArgs e)
        {
            ((ViewModel)this.AssociatedObject.DataContext).AddStateAttributes();
        }
        void OnFieldLayoutInitialized(object sender, Infragistics.Windows.DataPresenter.Events.FieldLayoutInitializedEventArgs e)
        {
            if( e.FieldLayout.ParentFieldName == "States")
            {
                ((ViewModel)this.AssociatedObject.DataContext).GridFieldLayout = e.FieldLayout;
            }            
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();            
            this.AssociatedObject.FieldLayoutInitialized -= OnFieldLayoutInitialized;
            this.AssociatedObject.RecordExpanded -= OnRecordExpanded;
        }
    }
