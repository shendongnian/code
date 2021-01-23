        private void DeleteSelectedItem()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var itemToDelete = (MyEntity)dataGridView1.SelectedRows[0].DataBoundItem;
            using (var connection = new OleDbConnection("..."))
            {
                connection.Open();
                using (var command = new OleDbCommand("DELETE FROM tb1 WHERE ID = ?", connection))
                {
                    // delete item from database
                    command.Parameters.AddWithValue("@Id", itemToDelete.Id);
                    command.ExecuteNonQuery();
                    // delete item from datasource and update DGV
                    var dataSource = (BindingList<MyEntity>)dataGridView1.DataSource;
                    dataSource.Remove(itemToDelete);
                }
            }
        }
