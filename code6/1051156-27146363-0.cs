     private void tbl_valuesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //totalling horizontally across rows
            int val1 = 0, val2 = 0, demo1;
            if (int.TryParse(tbl_valuesDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString().Trim(), out demo1))
                val1 = Convert.ToInt32(tbl_valuesDataGridView.Rows[e.RowIndex].Cells[1].Value);
            if (int.TryParse(tbl_valuesDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Trim(), out demo1))
                val2 = Convert.ToInt32(tbl_valuesDataGridView.Rows[e.RowIndex].Cells[2].Value);
            tbl_valuesDataGridView.Rows[e.RowIndex].Cells[3].Value = val1 + val2;
            
            //Adding vertically down the total column
            double sum = 0;
            for (int i = 0; i < tbl_valuesDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(tbl_valuesDataGridView.Rows[i].Cells[3].Value); //where 1 represents the index of the column you are adding
            }
            textBox1.Text = sum.ToString();
        }
