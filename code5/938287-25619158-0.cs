        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Resources.Contains["DataCtx1"])
            {
                MyDataSource dataSource = Resources["DataCtx1"] as MyDataSource;
                if (dataSource != null)
                {
                    dataSource.Close();
                }
            }
        }
