    class TextBoxWaterMark : TextBox
    {
    #region Datafields
    private string pm_WaterMark = "";
    #endregion
    #region Constructor
    public TextBoxWaterMark()
    {
    }
    #endregion
    #region Control events
    protected override void OnGotFocus(RoutedEventArgs e)
    {
      base.OnGotFocus(e);
      if ((string)this.Tag != "")
      {
        this.Foreground = new SolidColorBrush(Colors.Black);
        this.Text = "";
      }
    }
    protected override void OnLostFocus(RoutedEventArgs e)
    {
      base.OnLostFocus(e);
      if ((string)this.Tag != "")
      {
        if (this.Text == "")
        {
          this.Text = pm_WaterMark;
          this.Foreground = new SolidColorBrush(Colors.Gray);
        }
      }
    }
    #endregion
    #region Public get and set methods
    public string WaterMark 
    {
      get { return pm_WaterMark; } 
      set 
      {
        pm_WaterMark = value;
        this.Text = pm_WaterMark; 
        this.Foreground = new SolidColorBrush(Colors.Gray);
      } 
    }
    #endregion
