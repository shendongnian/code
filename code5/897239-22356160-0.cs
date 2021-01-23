    private void helpToolStripMenuItem_Click(object sender, EventArgs e)
    {
         foreach (Control ctrl in this.Controls)
         {
              if (!(ctrl is MdiClient))
                  ctrl.Hide();                                 
         }
    
         Help helpWindow=new Help();
         helpWindow.MdiParent = this;
         helpWindow.FormClosing += helpWindow_FormClosing;
         helpWindow.BringToFront();
         helpWindow.Show(); 
    }
    
    private void helpWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        foreach (Control ctrl in this.Controls)
        {
            ctrl.Show();
        }
    }
