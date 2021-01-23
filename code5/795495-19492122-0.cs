      public string ButtonText
      {
        get { return (string )this.GetValue(ButtonTextProperty); }
        set { this.SetValue(ButtonTextProperty, value); } 
      }
      public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register(
        "ButtonText", typeof(string), typeof(MyButton),new PropertyMetadata(false));
