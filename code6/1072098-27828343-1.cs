            DateTime dtValue = DateTime.Now;  // You Date Time Value
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if ((DateTime)r.Cells[6].Value > dtValue)
                {
                    r.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
            }
