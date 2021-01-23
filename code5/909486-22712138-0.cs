    void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && e.Clicks == 1)
        {
            dataGridView1.InvalidateCell(myClickedColumnHeaderIndex, -1); // this to trigger paint of the old cell inorder to remove the border drawn earlier.
            myClickedColumnHeaderIndex = e.ColumnIndex;
        }
    }
