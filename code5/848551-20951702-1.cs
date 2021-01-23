    private void DataGridViewMouseDownHandler(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Right)
        {
            var hti = dataGridView.HitTest(e.X, e.Y);
            dataGridView.ClearSelection();
            dataGridView.Rows[hti.RowIndex].Selected = true;
        }
    }
    this.dataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseDownHandler);
