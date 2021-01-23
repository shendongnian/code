        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double sum=0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sum+= Convert.ToDouble(DataGridView1.Rows[i].Cells[col].Value);
            }
            var newrowindex= dataGridView1.Rows.Add();
            DataGridViewRow summaryRow = dataGridView1.Rows[newrowindex];
            summaryRow.Cells[col].Value =sum;
        }
