    int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[colFirstDate.Name].Value = DateTime.Now;
            dataGridView1.Rows[index].Cells[colSecondDate.Name].Value = DateTime.Now.AddHours(3);
            DateTime firstDate = Convert.ToDateTime(dataGridView1.Rows[index].Cells[colFirstDate.Name].Value);
            DateTime secondDate = Convert.ToDateTime(dataGridView1.Rows[index].Cells[colSecondDate.Name].Value);
            TimeSpan timespan = secondDate - firstDate;
            if (timespan.Hours > 2)
            {
                dataGridView1.Rows[index].Cells[colFirstDate.Name].Style.BackColor = Color.Gray;
            }
