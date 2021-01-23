     public Brush LineColor
            {
                get
                {
                    return (Brush)GetValue(LineStrokeProperty);
                }
                set
                {
                    SetValue(LineStrokeProperty, value);
                    OnPropertyChanged("LineColor");
                }
            }
    
            
    
            public static readonly DependencyProperty LineStrokeProperty = DependencyProperty.Register("LineColor", typeof(Brush), typeof(RaClickableLine), new FrameworkPropertyMetadata(Brushes.White, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnLineStrokePropertyChanged), new CoerceValueCallback(OnLineStrokePropertyCoerceValue)), new ValidateValueCallback(OnLineStrokePropertyValidateValue));
    
            private static bool OnLineStrokePropertyValidateValue(object value)
            {
                return true;
            }
    
            private static object OnLineStrokePropertyCoerceValue(DependencyObject d, object baseValue)
            {
                return (Brush)baseValue;
            }
    
            private static void OnLineStrokePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((RaClickableLine)d).SetValue(LineStrokeProperty, (Brush)e.NewValue);
    
            }
            
    
    public RaClickableLine()
            {
                SetValue(FrameworkElement.NameProperty, "ClickableLine");
                Background = Brushes.AliceBlue;
                SnapsToDevicePixels = true;
    
                myLine.Stroke = Brushes.Blue;
                myLine.X1 = 0;
                myLine.X2 = ActualWidth;
                myLine.Y1 = 10;
                myLine.Y2 = 10;
    
                
                Binding b_width = new Binding();
                b_width.ElementName = "ClickableLine";
                b_width.Path = new PropertyPath("Width");
                b_width.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                myLine.SetBinding(Line.X2Property, b_width);
                
                Children.Add(myLine);
            }
