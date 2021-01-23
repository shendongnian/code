	private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			using (ContextMenu m = new ContextMenu())
			{
				MenuItem mItem = new MenuItem("Copy");
				m.MenuItems.Add(mItem);
				DataGridView.HitTestInfo information = dataGridView1.HitTest(e.X, e.Y);
				try
				{
					dataGridView1.CurrentCell = dataGridView1.Rows[information.RowIndex].Cells[information.ColumnIndex];
					m.Show(dataGridView1, new Point(e.X, e.Y));
					mItem.Click += mItem_Click;
				}
				catch (Exception)
				{
				}
			}
		}
	}
