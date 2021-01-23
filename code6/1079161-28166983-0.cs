    class PopupResizeBehaviors : Behavior<Thumb>
    {
        private const int MaxSize = 500;
        private const int MinSize = 50;
        protected override void OnAttached()
        {
            base.OnAttached();
            
            AssociatedObject.DragDelta += (s, e) =>
            {
                Thumb t = s as Thumb;
                if (t.Cursor == Cursors.SizeWE || t.Cursor == Cursors.SizeNWSE)
                {
                    PopupObject.Width = Math.Min(MaxSize,
                      Math.Max(PopupObject.Width + e.HorizontalChange,
                      MinSize));
                }
                if (t.Cursor == Cursors.SizeNS || t.Cursor == Cursors.SizeNWSE)
                {
                    PopupObject.Height = Math.Min(MaxSize,
                      Math.Max(PopupObject.Height + e.VerticalChange,
                      MinSize));
                }
            };
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
        public static readonly DependencyProperty PopupObjectProperty =
            DependencyProperty.RegisterAttached("PopupObject", typeof(Popup), typeof(PopupResizeBehaviors), new UIPropertyMetadata(null));
        public Popup PopupObject
        {
            get { return (Popup)GetValue(PopupObjectProperty); }
            set { SetValue(PopupObjectProperty, value); }
        }
    }
