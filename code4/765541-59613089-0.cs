    private void dataGridView1_Resize(object sender, EventArgs e)
        {
            int ColumnsWidth = 0;
            foreach(DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Visible) ColumnsWidth += col.Width;
            }
            if (ColumnsWidth <dataGridView1.Width)
            {
                dataGridView1.Columns["first_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (dataGridView1.Columns["first_name"].Width < 10) dataGridView1.Columns["first_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
