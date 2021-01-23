	private List<string> _boxAndFileList = new List<string>{"12345678","123456789"};
	public void PopulateItemsList()
	{
		BoxAndFileList.Items.Clear();
		BoxAndFileList.Columns.Add("Boxes");
		BoxAndFileList.Columns.Add("Files");
		BoxAndFileList.View = View.Details; 
		ScanIdBox.Text = string.Empty;
		var boxes = _boxAndFileList.Where(b => b.Length == 8).ToList();
		var files = _boxAndFileList.Where(b => b.Length != 8).ToList();
		var fileboxes = (from b in boxes 
						 from f in files
						 select new ListViewItem(new[] {b, f})).ToArray();
		BoxAndFileList.Items.AddRange(fileboxes);
		BoxAndFileList.Refresh();
	}
