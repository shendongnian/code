     private void studentDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                db.Save((student)studentBindingSource.Current);
            }
            catch (Exception)
            {
                return;
            }
        }
       
