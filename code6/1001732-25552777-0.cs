    RadioButton taskRb = new RadioButton();
	taskRb.CheckedChanged += new EventHandler(taskRb_CheckedChanged);
	taskRb.Text = DataGridTable.getTasks()[i].name.ToString();
	taskRb.Checked = false;
	ToolStripControlHost tRb = new ToolStripControlHost(taskRb);
	contextMenuStrip2.Items.Add(tRb);
	
	protected void taskRb_CheckedChanged(object sender, EventArgs e)
    {
        // Do stuff
    }
