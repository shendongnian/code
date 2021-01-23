    private void Form1_Load(object sender, System.EventArgs e)
    {
    	const string directoryPath = @"C:\slim\slimyyyy";
    	var printList = new List<string>();
    	foreach (string item in listBox1.Items)
    	{
    		var currentFilePath = Path.Combine(directoryPath, item);
    		if (File.Exists(currentFilePath))
    		{
    			printList.Add(item);
    		}
    	}
    	if (!printList.Any())
    	{
    		MessageBox.Show("File doesn't exist");
    		return;
    	}
    	foreach (string file in printList)
    	{
    		PrintDocument(file);
    		// Why you want to wait?? Let it print.
    	}
    }
