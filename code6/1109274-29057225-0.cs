        void dgvFE_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                textBox10.Text = (from DataGridViewRow r in dgvFE.Rows
                                 select Convert.ToDouble(r.Cells[e.ColumnIndex].Value))
                                 .Sum().ToString();
            }
        }
