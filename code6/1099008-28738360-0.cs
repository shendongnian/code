     private void CommitRow(object sender, DataGridRowEditEndingEventArgs e )
        {
           //FIRE WHEN ROW IS DONE EDIT
           /*
           STORING DATA TO DATABASE
           */
    
        Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
        {
            SelectRowByIndex(Datagrid, Datagrid.Items.Count - 1);
        }));
     }
    
