    public void simulareExamenToolStripMenuItem_Click(object sender, EventArgs e)
    {
       ToolStripMenuItem senderMenuItem = sender as ToolStripMenuItem;
       if(senderMenuItem != null)
       {
          categorie = senderMenuItem.Text;
       }
    }
