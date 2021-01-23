    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof (String), typeof(MyButton),null);
    
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
