       public Visibility UserImgRockVisibility
        {
            get { return (Visibility)GetValue(UserImgRockVisibilityProperty); }
            set { SetValue(UserImgRockVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for UserImgRockVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserImgRockVisibilityProperty =
            DependencyProperty.Register("UserImgRockVisibility", typeof(Visibility), typeof(UserControl1), new PropertyMetadata(Visibility.Hidden));
