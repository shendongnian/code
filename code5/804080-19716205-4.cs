    private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        //this will allow us to find out where we clicked in the datagridview
        DataGridView.HitTestInfo hti = dataGridView1.HitTest(e.X, e.Y);
        if (e.Button == MouseButtons.Left && hti.Type == DataGridViewHitTestType.Cell)
        {
            string URL = "";
            if (dataGridView1[hti.ColumnIndex, hti.RowIndex].Value != null)
            {
                //get the URL from the cell that you double-clicked on
                URL = dataGridView1[hti.ColumnIndex, hti.RowIndex].Value.ToString();
            }
            else
                return;
            //put your code to launch the URL in a browser here 
        }
    }
