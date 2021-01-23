        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(IEnumerable), typeof(AccountSelector), new UIPropertyMetadata((d, e) =>
            {
                if (e.NewValue == null) return;
                var s = d as AccountSelector;
                var list = e.NewValue as IEnumerable;
                if (list == null || s == null) return;
                if (s.UseComboBox)
                    s.AccCombo.ItemsSource = list;
                else
                    s.AccComplete.ItemsSource = list;                
            }));
        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }
