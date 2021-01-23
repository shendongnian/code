    sealed class GraphSettings
    {
      public Color BackgroundColor { get; set; }
      public Color ForegroundColor { get; set; }
    
      public string Title { get; set; }
    
      public double OffsetX { get; set; }
      public double OffsetY { get; set; }
    
      public bool ShowTitle { get; set; }
      public bool ShowText { get; set; }
    
      public GraphSettings()
      {
        // Set your default values here.
        this.ShowTitle = true;
      }
    }
