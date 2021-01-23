        public IList Figures
        {
            get
            {
                return (IList)GetValue (FiguresProperty);
            }
            set
            {
                SetValue (FiguresProperty, value);
            }
        }
        public static readonly DependencyProperty FiguresProperty =
            DependencyProperty.Register ("Figures", typeof (IList), typeof (Graph), new PropertyMetadata (new List<object>()));
