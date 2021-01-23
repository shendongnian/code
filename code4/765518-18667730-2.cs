    private List<string> _boxAndFileList = new List<string>{"12345678","123456789","1234", "123456778"};
	public void PopulateItemsList()
	{
		BoxAndFileList.Items.Clear();
		BoxAndFileList.Columns.Add("Files");
		BoxAndFileList.Columns.Add("Boxes");
		BoxAndFileList.View = View.Details; 
		ScanIdBox.Text = string.Empty;
		var boxes = _boxAndFileList.Where(b => b.Length == 8).ToList();
		var files = _boxAndFileList.Where(b => b.Length != 8).ToList();
		var fileboxes = (from f in files 
						 join b in boxes on f.index equals b.index into bf
						 from x in bf.DefaultIfEmpty()
						 select new ListViewItem(new { f.f, box = (x == null ? String.Empty : x.x) })).ToArray();
		BoxAndFileList.Items.AddRange(fileboxes);
		BoxAndFileList.Refresh();
	}
