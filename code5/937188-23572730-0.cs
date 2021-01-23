            DataGridTextColumn radiusColumn = new DataGridTextColumn();
            radiusColumn.Header = "radius";
            radiusColumn.Binding = new Binding("");
            MeasureDataGrid.Columns.Add(radiusColumn);
            MeasureDataGrid.ItemsSource = disc.MeasuredRadii;
