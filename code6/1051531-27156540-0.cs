        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty=
            DependencyProperty.Register("Text", typeof(string), typeof(MyButton), new PropertyMetadata("", HandleValueChange));
