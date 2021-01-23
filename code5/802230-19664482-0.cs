            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            for (int i = 0; i==dataGridView1.Rows.Count; i++ )
                if ((int)dataGridView1.Rows[i].Cells[0].Value > (int)dataGridView1.Rows[i].Cells[3].Value)
            {
                dataGridView1.Rows[i].Cells[0].Style = style;
            }
            else if ((int)dataGridView1.Rows[i].Cells[0].Value < (int)dataGridView1.Rows[i].Cells[3].Value)
            {
                
                dataGridView1.Rows[i].Cells[3].Style = style;
            }
