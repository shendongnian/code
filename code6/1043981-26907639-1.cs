    var processedLines = sList.Select(x => new ProcessedLine(x)).ToList();
    
    foreach (var processedLine in processedLines.OrderBy(x => x.SortKey1).ThenBy(x => x.SortKey2))
    {
    	if (lineObject.Original.Contains("3"))
    	{
    		dataGridView1.InvokeEx(control => control.Rows.Add(lineObject.Trimmed));
    		listBox1.InvokeEx(control => control.Items.Add("Processed Line: " + lineObject.Original));
    	}
    }
