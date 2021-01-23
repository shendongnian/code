    public class MyLLS : LongListSelector, INotifyPropertyChanged
    {
        // implement the INotify
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {            
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            // dat grab doe
            sb = this.GetTemplateChild("VerticalScrollBar") as System.Windows.Controls.Primitives.ScrollBar;
            sb.ValueChanged += sb_ValueChanged;           
        }
        void sb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // an animation has happen and they have moved a significance distance
            // set the new value
            ScrollValue = e.NewValue;
            
            // determine scroll direction
            if(e.NewValue > e.OldValue)
            {
                scroll_direction_down = true;
            }
            else
            {
                scroll_direction_down = false;
            }
        }
        public System.Windows.Controls.Primitives.ScrollBar sb;
        private bool scroll_direction_down = false;   // or whatever default you want
        public bool ScrollDirectionDown
        { get { return scroll_direction_down; }
        public double ScrollValue
        {
            get
            {
                if (sb != null)
                {
                    return sb.Value;
                }
                else
                    return 0;
            }
            set
            {
                sb.Value = value;
                NotifyPropertyChanged("ScrollValue");
            }
        }
    }
