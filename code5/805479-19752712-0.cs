	private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			ContextMenu m = new ContextMenu();
			MenuItem mItem = new MenuItem("Copy");
			m.MenuItems.Add(mItem);
			DataGridView.HitTestInfo val = dataGridView1.HitTest(e.X, e.Y);
			dataGridView1.CurrentCell = dataGridView1.Rows[val.RowIndex].Cells[val.ColumnIndex];
			m.Show(dataGridView1, new Point(e.X, e.Y));
			mItem.Click += mItem_Click;
		}
	}
