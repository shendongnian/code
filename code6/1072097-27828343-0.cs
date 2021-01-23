            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Cells[6].Value == "value to check")
                {
                    r.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
            }
