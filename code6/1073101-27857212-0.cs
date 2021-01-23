        List<MyItem> items = new List<MyItem>();
        for (int i = 0; i < 10; i++)
        {
            items.Add(new MyItem { Key = i, value = Image.FromFile(@"e:\test.jpg") });
        }
        this.dataGridView1.AutoGenerateColumns = false;
        this.dataGridView1.Columns.Clear();
        this.dataGridView1.Columns.Add("Key", "Key");
        this.dataGridView1.Columns.Add(new DataGridViewImageColumn() { HeaderText="Status"});
        this.dataGridView1.Columns[0].DataPropertyName = "Key";            
        this.dataGridView1.Columns[1].DataPropertyName = "value";
        this.dataGridView1.DataSource = items;
