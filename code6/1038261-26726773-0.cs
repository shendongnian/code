    // Parse the path-format string into a Geometry
    Geometry StringToPath(string pathData)
    {
        string xamlPath = 
            "<Geometry xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" 
            + pathData + "</Geometry>";
        
        return Windows.UI.Xaml.Markup.XamlReader.Load(xamlPath) as Geometry;
    }
    // In some function somewhere...
    // Set the path either directly
    test.Data = StringToPath("M 282.85714,355.21933 160,260.93361 260,169.50504 448.57143,163.79075 494.28571,286.6479 z");
    // Or via data binding
    PathGeometry = StringToPath("M 282.85714,355.21933 160,260.93361 260,169.50504 448.57143,163.79075 494.28571,286.6479 z");
    //....
    // If we want changes to the bound property to take effect we need to fire change notifications
    // Otherwise only the initial state will apply
    Geometry _geometry;
    public Geometry PathGeometry
    {
        get
        {
            return _geometry;
        }
        set
        {
            _geometry = value;
            NotifyPropertyChanged("PathGeometry");
        }
    }
