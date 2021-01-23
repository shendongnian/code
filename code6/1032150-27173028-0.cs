    var grid = new Grid()
    {
        VerticalOptions = LayoutOptions.FillAndExpand,
        ColumnDefinitions = new ColumnDefinitionCollection()
        {
            new ColumnDefinition(){ Width = new GridLength(250, GridUnitType.Absolute) },
            new ColumnDefinition(){ Width = new GridLength(250, GridUnitType.Absolute) },
            new ColumnDefinition(){ Width = new GridLength(250, GridUnitType.Absolute) },
            new ColumnDefinition(){ Width = new GridLength(250, GridUnitType.Absolute) },
            new ColumnDefinition(){ Width = new GridLength(250, GridUnitType.Absolute) },
            new ColumnDefinition(){ Width = new GridLength(250, GridUnitType.Absolute) }
        },
        RowDefinitions = new RowDefinitionCollection()
        {
            new RowDefinition(){ Height = new GridLength(1,GridUnitType.Star) },
            new RowDefinition(){ Height = new GridLength(1,GridUnitType.Star) },
            new RowDefinition(){ Height = new GridLength(1,GridUnitType.Star) }
        }
    };
    var scrollview = new ScrollView() { Orientation = ScrollOrientation.Horizontal };
    scrollview.Content = grid;
