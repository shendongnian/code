    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        for (int i = e.RowIndex; i < e.RowCount + e.RowIndex; i++)
        {
            //not tested: 
            string password = dataGridView1.Rows[e.RowIndex].Cells["encryptedPassword"].Value.ToString()
            string decryptedPassword = DataEncryptor.Decrypt(password);
            
            dataGridView1.Rows[e.RowIndex].Cells["encryptedPassword"].Value = decryptedPassword;
            Console.WriteLine("Row " + i.ToString() + " added");
        }
    }
