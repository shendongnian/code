	private void OnPreDragEnter(object sender, DragEventArgs e) {
		if (e.Data.GetDataPresent(typeof(ListViewItem))) {
			var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
			if (item.Tag is CustomDataObject) {
				e.Effect = DragDropEffects.Move;
			}
		}
	}
