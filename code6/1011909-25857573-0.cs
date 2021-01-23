    public Canvas IconResource
            {
                get { return (Canvas)GetValue(IconProperty); }
                set
                {
                    SetValue(IconProperty, value);
                }
            }
    
            public static readonly DependencyProperty IconProperty =
                DependencyProperty.Register("IconResource", typeof(Canvas), typeof(ButtonWithText), null);
