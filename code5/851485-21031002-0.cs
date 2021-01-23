        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public void IsSelectedChangedCallback()
        {
            //actions when property changed
        }
        private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            userControl.IsSelectedChangedCallback();
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(MyUserControl), new PropertyMetadata(new PropertyChangedCallback(OnSelectedChanged)));
