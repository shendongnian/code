    private void grdUser_RowEditingEnd(object sender, DataGridRowEditEndingEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
            {
                int currentRowIndex = this.grdUser.ItemContainerGenerator.IndexFromContainer(e.Row);
                MessageBox.Show(currentRowIndex.ToString());
            }));            
        }
