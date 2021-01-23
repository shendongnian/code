    public static readonly DependencyProperty MyTextProperty =
         DependencyProperty.Register("MyText", typeof(string), typeof(BuyerInput),
               new FrameworkPropertyMetadata
               {
                  BindsTwoWayByDefault = true,
                  DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                  PropertyChangedCallback = OnMyTextChanged
               });
    public string MyText
    {
       get { return (string)GetValue(MyTextProperty); }
       set { SetValue(MyTextProperty, value); }
    }
    private static void OnMyTextChanged(DependencyObject d, 
                                            DependencyPropertyChangedEventArgs args)
    {
    }
