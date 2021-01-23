        private void btnDelete_Click(object sender, EventArgs e)
        {
            // No row to delete?
            if(testTable1.CurrentRow == null)
                 return;
            // Get the cell value with the primary key
            int id = Convert.ToInt32(testTable1.CurrentRow.Cells[0].Value)
            // Start the database work...
            connectionstring = .....;
            using(con = new MySqlConnection(connectionstring))
            using(cmd = new MySqlCommand("DELETE FROM testdatabase where id = @id", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                // Fix the grid removing the current row
                testTable1.Rows.Remove(testTable1.CurrentRow);
                // Fix the underlying datasource 
                ((DataTable)testTable1.DataSource).AcceptChanges();
            }
        }
