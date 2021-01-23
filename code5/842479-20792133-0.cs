        List<Item> items = new List<Item>();
		items.Add(new Item() { Name = "One", Id = 1 });
		items.Add(new Item() { Name = "Two", Id = 2 });
		var cbo = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
		cbo.DataSource = items;
		cbo.ValueMember = "Id";
		cbo.DisplayMember = "Name";
		dataGridView1.Rows.Add("test", items[1].Id);
        ...
        public class Item
        {
	        public string Name { get; set; }
	        public int Id { get; set; }
        }
