      public Brush EnableColor
        {
            get { return (Brush)this.GetValue(EnableColorProperty); }
            set { this.SetValue(EnableColorProperty, value); }
        }
        public static readonly DependencyProperty EnableColorProperty = DependencyProperty.Register(
          "EnableColor", typeof(Brush), typeof(customRadioButton), new PropertyMetadata(default(Brush));
