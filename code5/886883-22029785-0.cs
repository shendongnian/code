    void Main()
    {
    	Form form = new Form();
    
    	ListView lv = new ListView();
    	lv.View = View.Details;
    	lv.Columns.Add(new ColumnHeader() { Name = "ip", Text = "IP Address" });
    	lv.Columns.Add(new ColumnHeader() { Name = "port", Text = "Port" });
    	lv.Dock = DockStyle.Fill;
    
    	// Tests.
    	AddItem(lv, "10.0.0.1", String.Empty);
    	AddItem(lv, "10.0.0.2", String.Empty);
    	AddItem(lv, "10.0.0.1", "8080");
    	AddItem(lv, "10.0.0.1", String.Empty);
    	AddItem(lv, "10.0.0.1", "8080");
    
    	form.Controls.Add(lv);
    	form.ShowDialog();
    }
    
    private void AddItem(ListView listView, string ip, string port)
    {
    	var items = listView.Items.Cast<ListViewItem>();
    	// First subitem starts at index 1.
    	bool exists = items.Where(item =>
    		(item.Text == ip && item.SubItems[1].Text == port)).Any();
    	if (!exists)
    	{
    		var item = new ListViewItem(ip);
    		item.SubItems.Add(new ListViewItem.ListViewSubItem(item, port));
    		listView.Items.Add(item);
    	}
    	else
    	{
    		Console.WriteLine("Duplicate: {0}:{1}", ip, port);
    	}
    }
