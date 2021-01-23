    public Color ChildForeColor
        {
            get { return (Color)GetValue(ChildForeColorProperty); }
            set { SetValue(ChildForeColorProperty, value); }
        }
        //Register Dependency ChildForeColor Property
        public static readonly DependencyProperty ChildForeColorProperty = DependencyProperty.Register("ChildForeColor", typeof(Color), typeof(SelectionArea), new FrameworkPropertyMetadata());
