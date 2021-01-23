            StringBuilder builder = new StringBuilder();
            foreach (DataGridViewRow rows in dataGridView2.SelectedRows)
            {
                var column1 = rows.Cells["dataGridViewTextBoxColumn2"].Value;
                var column2 = rows.Cells["dataGridViewTextBoxColumn1"].Value;
                builder.AppendLine(column1.ToString() + " - " + column2.ToString());
            }
            mailItem.Body = builder.ToString();
