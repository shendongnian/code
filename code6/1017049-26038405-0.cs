    public static readonly DependencyProperty LayoutXmlProperty = DependencyProperty.Register(
        "LayoutXml", typeof(string), typeof(WorkspaceLayoutControl),
        new FrameworkPropertyMetadata(defaultValue,
                                      new PropertyChangedCallback(OnLayoutXmlChanged));
    public string LayoutXml
    {
        get { return (string) GetValue(LayoutXmlProperty); }
        set { SetValue(LayoutXmlProperty, value); }
    }
 
    private static void OnLayoutXmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var layoutControl = d as WorkspaceLayoutControl;
        if (layoutControl != null)
        {
            layoutControl.RestoreLayout(layoutControl.LayoutXml);
        }
    }
