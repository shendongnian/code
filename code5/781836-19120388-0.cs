    public static class GridProps
    {
        public static readonly DependencyProperty CalculateCellSizesProperty = DependencyProperty.RegisterAttached(
            "CalculateCellSizes", typeof(bool), typeof(GridProps),
            new PropertyMetadata(false, (o, a) => CalculateCellSizes_OnChanged((Grid)o, a)));
        public static readonly DependencyProperty ForceCellSizesProperty = DependencyProperty.RegisterAttached(
            "ForceCellSizes", typeof(bool), typeof(GridProps),
            new PropertyMetadata(false, (o, a) => ForceCellSizes_OnChanged((Grid)o, a)));
        private static readonly DependencyProperty DummyGridProperty = DependencyProperty.RegisterAttached(
            "DummyGrid", typeof(Grid), typeof(GridProps),
            new PropertyMetadata(null));
        private static readonly DependencyPropertyKey RowActualHeightPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "RowActualHeight", typeof(double), typeof(GridProps),
            new PropertyMetadata(0.0));
        public static readonly DependencyProperty RowActualHeightProperty = RowActualHeightPropertyKey.DependencyProperty;
        private static readonly DependencyPropertyKey ColumnActualWidthPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "ColumnActualWidth", typeof(double), typeof(GridProps),
            new PropertyMetadata(0.0));
        public static readonly DependencyProperty ColumnActualWidthProperty = ColumnActualWidthPropertyKey.DependencyProperty;
        public static bool GetCalculateCellSizes (Grid grid)
        {
            return (bool)grid.GetValue(CalculateCellSizesProperty);
        }
        public static void SetCalculateCellSizes (Grid grid, bool value)
        {
            grid.SetValue(CalculateCellSizesProperty, value);
        }
        public static bool GetForceCellSizes (Grid grid)
        {
            return (bool)grid.GetValue(ForceCellSizesProperty);
        }
        public static void SetForceCellSizes (Grid grid, bool value)
        {
            grid.SetValue(ForceCellSizesProperty, value);
        }
        private static Grid GetDummyGrid (Grid grid)
        {
            return (Grid)grid.GetValue(DummyGridProperty);
        }
        private static void SetDummyGrid (Grid grid, Grid value)
        {
            grid.SetValue(DummyGridProperty, value);
        }
        public static double GetRowActualHeight (RowDefinition row)
        {
            return (double)row.GetValue(RowActualHeightProperty);
        }
        private static void SetRowActualHeight (RowDefinition row, double value)
        {
            row.SetValue(RowActualHeightPropertyKey, value);
        }
        public static double GetColumnActualWidth (ColumnDefinition column)
        {
            return (double)column.GetValue(ColumnActualWidthProperty);
        }
        private static void SetColumnActualWidth (ColumnDefinition column, double value)
        {
            column.SetValue(ColumnActualWidthPropertyKey, value);
        }
        private static void CalculateCellSizes_OnChanged (Grid grid, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
                grid.SizeChanged += Grid_OnSizeChanged;
            else
                grid.SizeChanged -= Grid_OnSizeChanged;
        }
        private static void Grid_OnSizeChanged (object sender, SizeChangedEventArgs args)
        {
            var grid = (Grid)sender;
            foreach (RowDefinition row in grid.RowDefinitions)
                SetRowActualHeight(row, row.ActualHeight);
            foreach (ColumnDefinition column in grid.ColumnDefinitions)
                SetColumnActualWidth(column, column.ActualWidth);
        }
        private static void ForceCellSizes_OnChanged (Grid grid, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue) {
                Action initDummyGrid = () => {
                    Grid parentGrid = (Grid)grid.Parent, dummyGrid = CreateDummyGrid(grid);
                    parentGrid.Children.Add(dummyGrid);
                    SetDummyGrid(grid, dummyGrid);
                };
                if (grid.IsLoaded)
                    initDummyGrid();
                else
                    grid.Loaded += (o, e) => initDummyGrid();
            }
            else {
                Grid parentGrid = (Grid)grid.Parent, dummyGrid = DestroyDummyGrid(grid);
                parentGrid.Children.Remove(dummyGrid);
                SetDummyGrid(grid, null);
            }
        }
        private static Grid CreateDummyGrid (Grid grid)
        {
            var dummyGrid = new Grid { Visibility = Visibility.Hidden };
            SetCalculateCellSizes(dummyGrid, true);
            foreach (RowDefinition row in grid.RowDefinitions) {
                var dummyRow = new RowDefinition { Height = row.Height, MinHeight = row.MinHeight, MaxHeight = row.MaxHeight };
                dummyGrid.RowDefinitions.Add(dummyRow);
                BindingOperations.SetBinding(row, RowDefinition.HeightProperty,
                    new Binding { Source = dummyRow, Path = new PropertyPath(RowActualHeightProperty) });
            }
            foreach (ColumnDefinition column in grid.ColumnDefinitions) {
                var dummyColumn = new ColumnDefinition { Width = column.Width, MinWidth = column.MinWidth, MaxWidth = column.MaxWidth };
                dummyGrid.ColumnDefinitions.Add(dummyColumn);
                BindingOperations.SetBinding(column, ColumnDefinition.WidthProperty,
                    new Binding { Source = dummyColumn, Path = new PropertyPath(ColumnActualWidthProperty) });
            }
            return dummyGrid;
        }
        private static Grid DestroyDummyGrid (Grid grid)
        {
            Grid dummyGrid = GetDummyGrid(grid);
            SetCalculateCellSizes(dummyGrid, false);
            foreach (RowDefinition row in grid.RowDefinitions)
                BindingOperations.ClearBinding(row, RowDefinition.HeightProperty);
            foreach (ColumnDefinition column in grid.ColumnDefinitions)
                BindingOperations.ClearBinding(column, ColumnDefinition.WidthProperty);
            return dummyGrid;
        }
    }
