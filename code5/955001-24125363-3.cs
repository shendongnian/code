    public string FirstName
    {
      get { return (string)GetValue(FirstNameProperty); }
      set { SetValue(FirstNameProperty, value); }
    }
    // Using a DependencyProperty as the backing store for MyProperty.
    //This enables animation, styling, binding, etc...
    public static readonly DependencyProperty FirstNameProperty =
      DependencyProperty.Register("FirstName", typeof(string), typeof(MainPage),
      new PropertyMetadata(string.Empty)); 
