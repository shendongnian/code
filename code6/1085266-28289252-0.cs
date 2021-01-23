    public static readonly DependencyProperty UidProperty = 
      DependencyProperty.RegisterAttached("Uid", typeof(string),
                                          typeof(TranslateExtension),
                               new UIPropertyMetadata(string.Empty, OnUidPropertyChanged));
    
    private static void OnUidPropertyChanged(DependencyObject d,
                                             DependencyPropertyChangedEventArgs args)
    {
       // Breakpoint will hit after ProvideValue in case of template.
    }
