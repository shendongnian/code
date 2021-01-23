           public static string filepath;
           private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
            using (OpenFileDialog fileChooser = new OpenFileDialog())
              {
                 fileChooser.Filter = "Xml Files (*.xml)|*.xml";
                 fileChooser.CheckFileExists = false;
                 result = fileChooser.ShowDialog();
                 filename = fileChooser.FileName;
                 Form2 form2=new Fomr2(filepath);
                 form2.ShowDialog();
                }
             }
    
