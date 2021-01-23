       public static readonly DependencyProperty MyTextProperty =
         DependencyProperty.Register("MyText", typeof(string),
         typeof(TextBoxControl), new FrameworkPropertyMetadata(""));
        public stringMyText
        {
            get { return (bool)GetValue(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }
     
