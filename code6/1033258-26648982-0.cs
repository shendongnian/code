     private void dataGridView3_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string unit = Convert.ToString(dataGridView3.Rows[i].Cells[6].Value);
                if (unit == "Unit1" || unit == "Unit2" || unit == "Unit3" || unit == "Unit4")
                {
                    for (int k = 7; k < dataGridView3.Rows[i].Cells.Count; k++)
                    {
                        int val = Convert.ToInt32(dataGridView3.Rows[i].Cells[k].Value);
                        if (val <= 12)
                        {
                            dataGridView3.Rows[i].Cells[k].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dataGridView3.Rows[i].Cells[k].Style.ForeColor = Color.Green;
                        }
                    }
                }
                else
                {
                    for (int j = 7; j < dataGridView3.Rows[i].Cells.Count; j++)
                    {
                        if (Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value) < 35)
                        {
                            dataGridView3.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                        else
                            dataGridView3.Rows[i].Cells[j].Style.ForeColor = Color.Green;
                    }
                }
            } 
        }
