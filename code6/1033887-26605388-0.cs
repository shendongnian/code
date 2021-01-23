    public static readonly DependencyProperty CustomSourceProperty
                = DependencyProperty.Register(
                          "CustomSource",
                          typeof(SourceList),
                          typeof(InteractiveGrid),
                          new FrameworkPropertyMetadata(null,
                              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                              CustomSourceChanged
                          )
                        );
    
    [Category("Group properties")]
    public SourceList CustomSource
    {
     get { return (SourceList)GetValue(CustomSourceProperty); }
     set { SetValue(CustomSourceProperty, value); }
    }
    
    private void CustomSourceChanged(SourceList sourceList)
    {
    //...
    }
    
    private static void CustomSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
     ((InteractiveGrid)d).CustomSourceChanged((SourceList)e.NewValue);
    }
