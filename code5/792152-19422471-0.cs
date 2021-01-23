    #region Dependancy Property
    // Dependency Property
    public static readonly DependencyProperty ElementsProperty =
         DependencyProperty.Register("Elements", typeof(ElementList),
         typeof(ElementGroup), new PropertyMetadata(null));
    // .NET Property wrapper
    public ElementList Elements {
      get { return (ElementList )GetValue(ElementsProperty ); }
      set { SetValue(ElementsProperty , value); }
    }
    #endregion
