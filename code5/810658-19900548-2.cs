    public string WaterMark
    {
      get { return (string )this.GetValue(WaterMarkProperty); }
      set { this.SetValue(WaterMarkProperty, value); } 
    }
    public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.Register(
     "WaterMark", typeof(string ), typeof(PasswordBoxWin8));
