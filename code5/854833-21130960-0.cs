    public LineStyleListBox()
    {
      InitializeComponent();      
      
      // do not add items if the control is in design mode
      if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        return;
         
      styleNames = System.Enum.GetNames(typeof(DashStyle));
      pens = new Pen[styleNames.Length];
      for (int i = 0; i != pens.Length; i++) 
      {
        pens[i] = new Pen(new SolidBrush(Color.Black), 1);
        pens[i].DashStyle = (DashStyle)i;
      }                          
      Items.AddRange(styleNames);          
    }
