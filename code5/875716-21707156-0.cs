    private void Form1_Load(object sender, EventArgs e)
    {
    	listBoxFiles.AllowDrop = true;
    	listBoxFiles.DragDrop += listBoxFiles_DragDrop;
    	listBoxFiles.DragEnter += listBoxFiles_DragEnter;
    }
    
    private void listBoxFiles_DragEnter(object sender, DragEventArgs e)
    {
    	if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }
    
    private void listBoxFiles_DragDrop(object sender, DragEventArgs e)
    {
    	string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
    	foreach (string file in files)
    		listBoxFiles.Items.Add(file);
    }
