    List<string> list = (from ListViewItem lvi in listView1.Items select lvi.Text).ToList();
    
    var duplicateQuery = list.GroupBy(text => text)
    	.Where(group => group.Count() > 1)
    			.Select(group => group.Key);
    string duplicateList = "";
    bool start = true;
    foreach (var duplicate in a)
    {
    	if (start)
    	{
    		start = false;
    		duplicateList += duplicate;
    	}
    	else duplicateList += ", " + duplicate;
    }
    TextBox1.Text = duplicateList;
