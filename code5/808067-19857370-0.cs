     private ItemsControl _correlationGrid;
    public ItemsControl CorrelationGrid
    {
        get { return _correlationGrid; }
        set 
        { 
            _correlationGrid = value;
            RaisePropertyChanged("CorrelationGrid");
        }
    }
    private void RefreshCorrelationGrid()
    {
        var resourceDictionary = new ResourceDictionary { Source = new Uri("/WMA.GUI;component/Styles.xaml", UriKind.RelativeOrAbsolute) };
        var grid = new DataGrid
                       {
                           HeadersVisibility = DataGridHeadersVisibility.All,
                           GridLinesVisibility = DataGridGridLinesVisibility.All,
                           Background = Brushes.Transparent,
                           CanUserAddRows = false,
                           CanUserResizeColumns = false,
                           CanUserReorderColumns = false,
                           CanUserSortColumns = false,
                           CanUserResizeRows = false,
                           AutoGenerateColumns = false,
                           HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
                           BorderThickness = new Thickness(0),
                           RowHeaderTemplate = resourceDictionary["DataGridRowHeaderTemplate"] as DataTemplate,
                           RowHeaderStyle = resourceDictionary["DataGridRowHeader"] as Style,
                           RowHeaderWidth = 35,
                           SelectionMode = DataGridSelectionMode.Single,
                           RowHeight = 21,
                           VerticalContentAlignment = VerticalAlignment.Center
                       };
        var tableRows = new ObservableCollection<CorrelationTableRowViewModel>();
        var index = 0;
        foreach (var ccy in _availableCcys.OrderBy(c => c).Where(c => !c.ToUpper().Equals("USD")))
        {
            var row = new CorrelationTableRowViewModel(ccy);
            tableRows.Add(row);
            grid.Columns.Add(GetCorrelationColumn(row, index, resourceDictionary));
            foreach (var ccyMapping in _availableCcys.OrderBy(c => c).Where(c => !c.ToUpper().Equals("USD")))
            {
                var correlation = _fxCorrelations.FirstOrDefault(f => (f.CcyOne == row.Ccy && f.CcyTwo == ccyMapping) || f.CcyTwo == row.Ccy && f.CcyOne == ccyMapping);
                
                // If for some reason we don't have a mapped correlation for this ccy pairing, create it now
                if (correlation == null)
                {
                    correlation = new FxCorrelation(row.Ccy, ccyMapping, 0.0m);
                    _fxCorrelations.Add(correlation);
                }
                    
                row.Correlations.Add(correlation);
            }
            index++;
        }
        grid.ItemsSource = tableRows;
        grid.Loaded += GridLoaded;
        CorrelationGrid = grid;
    }
    private DataGridTextColumn GetCorrelationColumn(CorrelationTableRowViewModel row, int index, ResourceDictionary resourceDictionary)
    {
        // This gives us a setter we can use to assign background colours to correlation cells that have been modified
        var highlightStyleSetter = new Setter
        {
            Property = Control.BackgroundProperty,
            Value = resourceDictionary["GridModifiedCellBackground"] as Brush
        };
        var highlightStyle = new Style(typeof(DataGridCell));
        var trigger = new DataTrigger { Binding = new Binding("Correlations[" + index + "].Modified"), Value = true };
        trigger.Setters.Add(highlightStyleSetter);
        highlightStyle.Triggers.Add(trigger);
        return new DataGridTextColumn
            {
                Header = row.Ccy, 
                Width = new DataGridLength(50),
                Binding = new Binding("Correlations[" + index + "].Amount") { Mode = BindingMode.TwoWay, StringFormat = "0.####"},
                HeaderStyle = resourceDictionary["DataGridColumnHeader"] as Style,
                ElementStyle = resourceDictionary["DataGridTextStyle"] as Style,
                CellStyle = highlightStyle
            };
    }
    private static void GridLoaded(object sender, RoutedEventArgs e)
    {
        var dep = sender as DependencyObject;
        while (!(dep is Button))
        {
            if (dep == null) return;
            if (VisualTreeHelper.GetChildrenCount(dep) == 0) return;
            dep = VisualTreeHelper.GetChild(dep, 0);
        }
        var resourceDictionary = new ResourceDictionary { Source = new Uri("/WMA.GUI;component/Styles.xaml", UriKind.RelativeOrAbsolute) };
        var button = dep as Button;
        button.Template = resourceDictionary["SelectAllButtonTemplate"] as ControlTemplate;
    }
