        public static readonly DependencyProperty DynamicTextProperty =
           DependencyProperty.Register(
              "DynamicText",
              typeof(string),
              typeof(FacebookAutoComplete),
              new FrameworkPropertyMetadata(null));
        public string DynamicText
        {
            get { return (string)GetValue(DynamicTextProperty); }
            set { SetValue(DynamicTextProperty, value); }
        }
