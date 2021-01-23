    private void CreatePivotTableButton(object sender, RoutedEventArgs e)
    {
    
        this.StatusToBeDisplayed.Content = "Creating...";
        this.DescriptionLabel.IsEnabled = false;
        this.TextBlockBorder.IsEnabled = true; 
    
        List<CombinedData> items = (List<CombinedData>)CustomerComboBox.ItemsSource;
        List<int> selectedItems = new List<int>();
        foreach (CombinedData item in items)
        {
            if (item.IsSelected)
            {
                selectedItems.Add(item.ReferenceId);
            }
        }
    
        PCTProvider provider = new PCTProvider();
        ExportToExcel export = new ExportToExcel();
    
        ExcelAutomation excelAutomation = new ExcelAutomation();
    
        this.ResultTextBlock.Text = "Establishing Connection";
        DataTable generateReportDataTable = provider.GetReportData(selectedItems);
        Excel.Workbook workbook = export.ExportDataTableToExcel(generateReportDataTable);
        Task updateTask = Task.Factory.StartNew(() =>
        {
            excelAutomation.CreatePivotTable(workbook);
            Dispatcher.Invoke(new Action(() => this.StatusToBeDisplayed.Content = "Done!"));
            Dispatcher.Invoke(new Action(() => OriginalStatus()));
        });
    }
