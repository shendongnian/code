    private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                summition();
            }
        }
        void summition() 
        { 
            double sum = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if(!row .IsNewRow )
                    sum += Convert.ToDouble(row.Cells [0].Value .ToString () );
            }
             
            textBox9.Text = sum.ToString();
        }
