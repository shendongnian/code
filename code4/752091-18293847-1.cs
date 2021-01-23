    // populate this in constructor, via service, setter, etc - whatever makes sense
    private string[] data;
    // how many rows are in the table
    public int NumberOfRowsInTableView(NSTableView table)
    {
      return data.length;
    }
    
    // what to draw in the table
    public NSObject ObjectValueForTableColumn (NSTableView table, NSTableColumn col, int row)
    {
      // assume you've setup your tableview in IB with two columns, "Index" and "Value"
      string text = string.Empty;
      if (col.HeaderCell.Title == "Index") {
	text = row.ToString();
      } else {
        text = data [row];
      }
      return new NSString (text);
    }
