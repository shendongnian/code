    private ListViewItem tempItem = null;
    private void lvTables_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			Application.DoEvents();
			tempItem = lvTables.GetItemAt(e.X, e.Y);
			string sData = tempItem.Text + ":" + tempItem.Name;
			DragDropEffects effect = DoDragDrop(sData, DragDropEffects.Move);
			lvTables.Refresh();
		}		
	}
	private void lvTables_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.StringFormat))
			e.Effect = DragDropEffects.Move;
		else
			e.Effect = DragDropEffects.None;
	}
	private void lvTables_DragOver(object sender, DragEventArgs e)
	{
		if (tempItem != null && lvTables.Items.Contains(tempItem))
		{
			Application.DoEvents();
			int iIndex = -1;
			try
			{
				Point p = lvTables.PointToClient(new Point(e.X, e.Y));
				iIndex = lvTables.GetItemAt(p.X, p.Y).Index;
			}
			catch
			{ }
			if (iIndex > -1 && iIndex != tempItem.Index)
			{
				if (lvTables.Items.Contains(tempItem))
					lvTables.Items.Remove(tempItem);
				lvTables.Items.Insert(iIndex, tempItem);
				tempItem.Selected = true;
			}
		}
	}
	private void lvTables_MouseUp(object sender, MouseEventArgs e)
	{
		if (tempItem != null)
		{
			lvTables.SelectedItems.Clear();
			tempItem.Selected = true;
			tempItem = null;
		}
	}
