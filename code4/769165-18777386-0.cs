    private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e){
       e.Cancel = true;//Cancel the actual deletion of row
       //You can just hide the row instead
       e.Row.Visible = false;
       //Then set the IsDeleted of the underlying data bound item to true
       ((YourObject)e.Row.DataBoundItem).IsDeleted = true;
    }
