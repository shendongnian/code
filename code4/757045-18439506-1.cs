    using myApplication.Properties;
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
         {
             Settings.Default.Visible = toolStrip.Visible ;
             Settings.Default.Save(); 
         }
