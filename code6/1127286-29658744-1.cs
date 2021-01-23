    private void listeContinentToolStripMenuItem_Click(object sender, EventArgs e)
	{
		listecont flc = new listecont();
        flc.SetContinentData(listec);
		flc.ShowDialog();
		flc.MdiParent = this;      
	}
