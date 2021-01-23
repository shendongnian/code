    private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Microsoft.VisualBasic.Interaction.InputBox("Please enter a save file name.", "Save Game");
                if (fileName.Equals(""))
                {
                    MessageBox.Show("Please enter a valid save file name.");
                }
                else
                {
                    fileName = String.Concat(fileName, ".gls");
                    MessageBox.Show("Saving to " + fileName);
    
                    System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory +  fileName, saveScene.ToString());
                }
            }
            catch (Exception f)
            {
                System.Diagnostics.Debug.Write(f);
            }
        }
