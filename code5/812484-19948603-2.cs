      public string Title
      {
        get { return (string)this.GetValue(TitleProperty); }
        set { this.SetValue(TitleProperty, value); } 
      }
    
      public static readonly DependencyProperty TitleProperty = 
                     DependencyProperty.Register("Title",
                                                 typeof(string),
                                                 typeof(MyControl),
                                                 new PropertyMetadata(null));
