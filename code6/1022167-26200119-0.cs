    private string[] B1file;
    private void B1_Click(object sender, EventArgs e)
    {
    	foreach (var item in B1file)
    	{
    		Process.Start(item);
    	}
    }
    
    private void B1_DragDrop(object sender, DragEventArgs e)
    {
       B1file = (string[])e.Data.GetData(DataFormats.FileDrop, false);
    }
