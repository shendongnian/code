    try
    {
    	//connectDB is the procedure to connect to database:
        connectDB();
        //this delete first the selected rows in database, and then update datagrid
        int countRows = dataGridView1.SelectedRows.Count;
        for (int i = 0; i < countRows; i++)
        {
            int currentRow = dataGridView1.SelectedRows[0].Index;
    		//con.oledbcon is the conecction is the OleDbConnection procedure, miTable = name of your table
            OleDbCommand com = new OleDbCommand("DELETE FROM miTable WHERE Id=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), con.oledbcon);
    		// delete from database
            com.ExecuteNonQuery();
    		// THIS IS THE KEY!!! deselect the last row selected to be able to delete the next row in the next loop
            dataGridView1.Rows[currentRow].Selected = false;
        }
    	// all OK
        MessageBox.Show("Rows deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
    	//in case of error
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    finally
    {
    	//disconnectDB is the procedure to disconnect to database:
        disconnectDB();
    	// and finally, refill datagrid again
        loaddatagrid();
    }
