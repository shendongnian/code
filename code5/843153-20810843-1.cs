    public static readonly DependencyProperty SelectedItemGUIDProperty = DependencyProperty.Register("SelectedItemGUID",typeof(Guid?),typeof(UserControl),new FrameworkPropertyMetadata(null));
        public Guid? SelectedItemGUID
        {
            public Guid? SelectedItemGUID
        {
            get { return (Guid?)GetValue(SelectedItemGUIDProperty); }
            set { SetValue(SelectedItemGUIDProperty, (Guid?)SelectedItem.GetType().GetProperty("GUID").GetValue(SelectedItem, null)); }
        }
        }
