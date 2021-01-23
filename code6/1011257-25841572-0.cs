	private void startLoop()
	{
		for(int a = 0; a< strip.Items.Count;a++)
			recursiveLoop(strip.Items[a]);
	}
	private void recursiveLoop(ToolStripMenuItem item)
	{
		//DO YOUR LOGIC HERE
		item.Visible = true;
		//
		for(int a = 0; a< item.Items.Count;a++)
			recusiveLoop(item.Items[a]);
	}
