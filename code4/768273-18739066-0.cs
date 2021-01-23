        public static readonly DependencyProperty ClearMeProperty = DependencyProperty.Register
            (
                 "ClearMe",
                 typeof(bool),
                 typeof(MyControl),
                 new FrameworkPropertyMetadata(false, OnClearMeChanged)
            );
    
            public bool ClearMe
            {
                get { return (bool)GetValue(ClearMeProperty); }
                set { SetValue(ClearMeProperty, value); }
            }
    
            private static void OnClearMeChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
               var control = sender as MyControl;
               if((bool)e.NewValue)
               {
                   control.Refresh()
               }
            }
