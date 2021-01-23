    private List<string> _boxAndFileList = new List<string> { "12345678", "123456789", "1234", "123456778" };
	public void PopulateItemsList()
	{
		//clear the list
		BoxAndFileList.Items.Clear();
		//add the labels to the top of the listbox
		BoxAndFileList.Columns.Add("Boxes");
		BoxAndFileList.Columns.Add("Files");
		//set the view of the list to a details view (important if you try to display images)
		BoxAndFileList.View = View.Details;
		//clear scan id box
		ScanIdBox.Text = string.Empty;
		//get all the items whos length are 8 as well as a unique id (index)
		var boxes = _boxAndFileList.Where(b => b.Length == 8).Select((b, index) => new { index, b }).ToList();
		//get all the items whos length are NOT 8 as well as a unique id (index)
		var files = _boxAndFileList.Where(f => f.Length != 8).Select((f, index) => new { index, f }).ToList();
		//join them together on their unique ids so that you get info on both sides.
		var interim = (from f in files
					   join b in boxes on f.index equals b.index into bf
					   from x in bf.DefaultIfEmpty()
					   select new { box = (x == null ? String.Empty : x.b), file = f.f });
		//the real trick here is that you have to add 
		//to the listviewitem of type string[] in order to populate the second, third, or more column.
		//I'm just doing this in linq, but var x = new ListViewItem(new[]{"myBox", "myFile"}) would work the same
		var fileboxes = interim.Select(x => new ListViewItem(new []{ x.box, x.file})).ToArray();
		//add the array to the listbox
		BoxAndFileList.Items.AddRange(fileboxes);
		//refresh the listbox
		BoxAndFileList.Refresh();
	}
