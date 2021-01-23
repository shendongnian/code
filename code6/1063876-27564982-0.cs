        public Window2()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                myGrid.RowDefinitions.Add(rowDef);
            }
            // define the columns
            // column for Line
            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(8, GridUnitType.Star);
            myGrid.ColumnDefinitions.Add(colDef1);
            // column for TextBlock
            ColumnDefinition colDef2 = new ColumnDefinition();
            colDef2.Width = new GridLength(1, GridUnitType.Star);
            myGrid.ColumnDefinitions.Add(colDef2);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                // draw dashed line
                Line line = new Line()
                {
                    X2 = myGrid.ColumnDefinitions[0].ActualWidth, // actual width is 0
                    Stroke = Brushes.Black,
                    StrokeDashArray = { 10, 10, 10, 10 },
                    StrokeThickness = 1
                };
                Grid.SetRow(line, i);
                Grid.SetColumn(line, 0);
                myGrid.Children.Add(line);
                // draw text
                Viewbox vb_txtBlock = new Viewbox();
                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = "Line " + (i + 1);
                vb_txtBlock.Child = txtBlock;
                Grid.SetRow(vb_txtBlock, i);
                Grid.SetColumn(vb_txtBlock, 1);
                myGrid.Children.Add(vb_txtBlock);
            }
        }
