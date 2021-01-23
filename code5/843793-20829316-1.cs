    if (affectedRows > 0)
    {
        if (MessageBox.Show("Table Saved!", "Update", MessageBoxButtons.OK) == DialogResult.OK)
        {
            //refreshMyGrid
            RefreshMyDataGridView1();
        }
    }
