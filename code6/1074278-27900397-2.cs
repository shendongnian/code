    private void createGridInForm(int rows, int columns)
    {
        DataGridView RunTimeCreatedDataGridView = new DataGridView();
        RunTimeCreatedDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        myTabPage.Controls.Add(RunTimeCreatedDataGridView);
        RunTimeCreatedDataGridView.DataSource = createGridForForm(rows, columns);
        // fill the gridview to its container
        DataGridViewColumn ID_Column = RunTimeCreatedDataGridView.Columns[0];
        ID_Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        RunTimeCreatedDataGridView.Dock = DockStyle.Fill;
    }
