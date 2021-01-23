    public class SyncedLongListSelector : LongListSelector
    {
        private ScrollBar scrollBar;
        private static readonly Dictionary<string, List<SyncedLongListSelector>> Groupings = new Dictionary<string, List<SyncedLongListSelector>>();
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(SyncedLongListSelector), new PropertyMetadata(default(string)));
        public string GroupName
        {
            get
            {
                return (string)GetValue(GroupNameProperty);
            }
            set
            {
                SetValue(GroupNameProperty, value);
            }
        }
        public override void OnApplyTemplate()
        {
            scrollBar = GetTemplateChild("VerticalScrollBar") as ScrollBar; // See my comments
            if (scrollBar != null)
                scrollBar.Scroll += OnScroll;
            base.OnApplyTemplate();
        }
        private void UpdateScrolPosition(double scrollBarValue)
        {
            scrollBar.Value = scrollBarValue;
        }
        private void OnScroll(object sender, ScrollEventArgs args)
        {
            foreach (var otherList in Groupings[GroupName].Where(l => !Equals(l, this)))
                otherList.UpdateScrolPosition(scrollBar.Value);
        }
    }
