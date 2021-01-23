    protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                _template = LayoutRoot.Resources["DataGridRowTemplate"] as ControlTemplate;
                MySilverlightDataGrid.ItemsSource = _employees;
                MySilverlightDataGrid.LoadingRow += MySilverlightDataGrid_LoadingRow;
            }
    
            void MySilverlightDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
            {
                DataGridRow row = DataGridRow.GetRowContainingElement(e.Row);
                var rowEmployee = row.DataContext as Employee;
                if (rowEmployee != null && !rowEmployee.IsEmployeed)
                {
                    row.Template = _template;
                }
            }
    
            private readonly IEnumerable<Employee> _employees;
            private ControlTemplate _template;
