            //button creates datagrid as desired dimension
        private void btKenarRaporOlustur_Click(object sender, EventArgs e)
        {
            KenarRaporuOlustur((int)nudKenarKolonAdet.Value, (int)nudKenarSatirAdet.Value);
        }
        //gird creator
        private void KenarRaporuOlustur(int columns, int rows)
        {//           
            var dtKenar = new DataTable();
            for (int j = 0; j < columns; j++)
            {
                dtKenar.Columns.Add(j.ToString(CultureInfo.InvariantCulture));
            }
            for (int i = 0; i < rows; i++)
            {
                dtKenar.Rows.Add();
            }
            dataGridView1.DataSource = dtKenar;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = 25;
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
        }
        //grid mouse click event
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.Selected = false;
            cell.Style.BackColor = cell.Style.BackColor == Color.Black ? Color.White : Color.Black;
            cell.Value = cell.Value.ToString() == "1" ? null : "1";
        }
