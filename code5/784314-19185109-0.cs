    private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
          Dispatcher.BeginInvoke(
             new Action(()=>this.db_test_directoryEntities1.SaveChanges()), 
             System.Windows.Threading.DispatcherPriority.Background);
    }
