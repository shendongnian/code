    dataGrid.AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
    void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        e.Column.Visibility = Visibility.Collapsed;
    }
