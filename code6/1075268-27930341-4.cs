    DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
    btnCol.HeaderText = "Foo";
    btnCol.Name = "Bar";
    btnCol.Text = "Click Me";
    btnCol.UseColumnTextForButtonValue = true;
    this.dataGridView1.Columns.Add(btnCol);
    this.dataGridView1.CellClick += new DataGridViewCellEventHandler(col_Click);
