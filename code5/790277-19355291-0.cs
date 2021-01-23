    public static readonly DependencyProperty AProperty =
                DependencyProperty.Register("A", typeof(double),
                typeof(MyControl), new FrameworkPropertyMetadata(OnAorBChange));
    
            public double A
            {
                get { return (double)GetValue(AProperty); }
                set { SetValue(AProperty, value); }
            }
    
            public static readonly DependencyProperty BProperty =
                    DependencyProperty.Register("B", typeof(double),
                    typeof(MyControl), new FrameworkPropertyMetadata(OnAorBChange));
    
            public double B
            {
                get { return (double)GetValue(BProperty); }
                set { SetValue(BProperty, value); }
            }
    
            public static readonly DependencyProperty CProperty =
               DependencyProperty.Register("C", typeof(double),
               typeof(MyControl), new FrameworkPropertyMetadata(null));
    
            public double C
            {
                get { return (double)GetValue(CProperty); }
                set { SetValue(CProperty, value); }
            }
    
            private static void OnAorBChange(DependencyObject obj,
               DependencyPropertyChangedEventArgs args)
            {
                var obj1 = obj as MyControl;
                obj1.C = obj1.A + obj1.B;
            }
