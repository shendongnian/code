        public new object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set 
            { 
                SetValue(SelectedItemProperty, value);
                base.SelectedItem = value;
            }
        }
