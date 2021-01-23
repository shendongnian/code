		private void Form1_Load(object sender, EventArgs e)
		{
			var dt = new DataTable();
			dt.Columns.Add("Id");
			dt.Columns.Add("Value");
			dt.Columns.Add("ComboID");
			var drow = dt.NewRow();
			drow[0] = 10;
			drow[1] = "abc";
			dt.Rows.Add(drow);
			drow = dt.NewRow();
			drow[0] = 20;
			drow[1] = "xy";
			dt.Rows.Add(drow);
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id" });
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Value" });
			var dtOrders = new DataTable();
			dtOrders.Columns.Add("OrdersID");
			dtOrders.Columns.Add("Orders");
			drow = dtOrders.NewRow();
			drow[0] = 1;
			drow[1] = "Order1";
			dtOrders.Rows.Add(drow);
			drow = dtOrders.NewRow();
			drow[0] = 2;
			drow[1] = "Order2";
			dtOrders.Rows.Add(drow);
			var combo = new DataGridViewComboBoxColumn();
			combo.DataSource = dtOrders;
			combo.DataPropertyName = "ComboID";
			combo.ValueMember = "OrdersID";
			combo.DisplayMember = "Orders";
			dataGridView1.Columns.Add(combo);
			dataGridView1.DataSource = dt;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			var dt = dataGridView1.DataSource as DataTable;
		}
