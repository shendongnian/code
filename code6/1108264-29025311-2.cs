    private async void button1_Click(object sender, EventArgs e)
    {
        Progress<Tuple<int, int>> progress = new Progress<Tuple<int, int>>();
        progressBar1.Minimum = 0;
        progressBar1.Maximum = stats.EndRowIndex;
        progressBar1.Step = 1;
        progress.ProgressChanged += (sender, progressInfo) =>
        {
            lblStatus.Text = "Reading row " + progressInfo.Item1 + " of " + progressInfo.Item2;
            progressBar1.PerformStep();
        };
        // I don't know where filePath comes form...initialize to suit your needs
        string filePath = ...;
        List<DataRow> table = await Task.Run(() => GeExcelData(filePath, progress));
        lblStatus.Text = "";
        progressBar1.Value = 0;
        // do something with table
    }
    public List<DataRow> GeExcelData(string filePath, IProgress<Tuple<int, int>> progress)
    {
        var myTable = new List<DataRow>();
        int row = 0;
    
        using (var input = new SLDocument(filePath))
        {
            SLWorksheetStatistics stats = input.GetWorksheetStatistics();
            int iStartColumnIndex = stats.StartColumnIndex;
    
            for (row = stats.StartRowIndex + 1; row <= stats.EndRowIndex; ++row)
            {
                progress.Report(Tuple.Create(row, stats.EndRowIndex));
                var dataRowTmp = new DataRow()
                {
                    name = input.GetCellValueAsString(row, iStartColumnIndex),
                    sku = input.GetCellValueAsString(row, iStartColumnIndex + 1),
                    value2 = input.GetCellValueAsString(row, iStartColumnIndex + 2),
                    value3 = input.GetCellValueAsString(row, iStartColumnIndex + 3)
                };
    
                myTable.Add(dataRowTmp);
            }
        }
    
        return myTable;
    }
