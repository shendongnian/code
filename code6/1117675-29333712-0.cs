    enum LastFocusedEntityType { None, Record, Row }
    class LastFocusedEntityTrackingBehavior : Behavior<UIElement>
    {
        public static readonly LastFocusedEntityProperty = DependencyProperty.Register(
            "LastFocusedEntity", 
            typeof(LastFocusedEntityType), 
            typeof(LastFocusedEntityTrackingBehavior),
            LastFocusedEntityType.None);
        public LastFocusedEntityType LastFocusedEntity
        {
            get { return (LastFocusedEntityType)this.GetValue(LastFocusedEntityProperty); }
            set { this.Setvalue(LastFocusedEntityProperty, value); }
        }
        protected override void OnAttached()
        {
            Keyboard.AddPreviewLostKeyboardFocusHandler(this.AssociatedObject, this.PreviewLostKeyboardFocusHandler);
        }
        private void PreviewLostKeyboardFocusHandler(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.OldFocus is DataGrid)
            {
                this.LastFocusedEntity = LastFocusedEntityType.Row;
            }
            else
            {
                this.LastFocusedEntity = LastFocusedEntityType.Record;
            }
        }
    }
