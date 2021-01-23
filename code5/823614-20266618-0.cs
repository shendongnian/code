        private DataTable dataTable;
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.dataTable = new DataTable();
            // Add your data here
            this.dataTable.Columns.Add("Col1");
            this.dataTable.Rows.Add("1");
            this.dataTable.Rows.Add("2");
            this.dataTable.Rows.Add("3");
            this.dataTable.Rows.Add("4");
            this.dataTable.Rows.Add("5");
        }
        void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ListView1.DataContext = this.dataTable.DefaultView;
        }
