            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Name = "target_column";
            imageCol.DisplayIndex = dataGridView1.Columns["source_column"].DisplayIndex + 1;
            dataGridView1.Columns.Add(imageCol);
            for(int index = 0; index < dt.Rows.Count; index ++)
            {
                dataGridView1.Rows[index].Cells["target_column"].Value = dt.Rows[index]["source_column"];
            }
            dt.Columns.Remove("source_column");
