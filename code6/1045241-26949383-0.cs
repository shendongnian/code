    private void grdInfoSave(object sender, DataGridRowEditEndingEventArgs e )
     {
          if (e.EditAction == DataGridEditAction.Commit)
          {
            //Try to get the user inserted value and process it
            DataRow newrow= e.Row.DataContext as DataRow; // If datarow does not work, replace will required databind class.
            String new_desc = newrow["Description"].ToString();
            DataRowView row = (DataRowView)grdQuoteDetail.SelectedItem;
            int No = Convert.ToInt32(row["No"]);
          }
     }
