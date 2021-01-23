    public static readonly DependencyProperty IsNotCurrentProperty =
      DependencyProperty.Register("IsNotCurrent", typeof(bool),
      typeof(MyListBox), new FrameworkPropertyMetadata(false));
    
    public bool IsNotCurrent
    {
      get { return (bool)GetValue(IsNotCurrentProperty); }
      set { SetValue(IsNotCurrentProperty, value); }
    }
