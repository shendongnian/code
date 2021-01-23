    SaveFileDialog sdlg = new SaveFileDialog();
    sdlg.FileOk += CheckIfFileHasCorrectExtension;
    sdlg.Filter = "CSV Files (*.csv)|*.csv";
    if(sdlg.ShowDialog() == DialogResult.OK)
        Console.WriteLine("Save file:" + sdlg.FileName);
     void CheckIfFileHasCorrectExtension(object sender, CancelEventArgs e)
     {
         string[] files = (sender as SaveFileDialog).FileNames;
         foreach( string file in files )
         {
             if(Path.GetExtension(file).ToLower() != ".csv")
             {
                 e.Cancel = true;
                 MessageBox.Show("Please omit the extension or use 'CSV'");
                 return;
             }
         }
     }
