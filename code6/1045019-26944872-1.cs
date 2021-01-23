        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.Columns.Add("name", "Name");
        dataGridView1.Columns.Add(new DataGridViewImageColumn(false));
        dataGridView1.Columns[0].DataPropertyName = "name";
        dataGridView1.Columns[1].DataPropertyName = "icon";
