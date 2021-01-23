    SaveFileDialog sDlg = new SaveFileDialog();
    
    if (sDlg.ShowDialog() == DialogResult.OK)
    {
         FileStream f = new FileStream(sDlg.FileName, FileMode.Create);
         Console.WriteLine(f.Name); // This will print the correct filename
         f.Close();
         Console.ReadLine();
    }
    sDlg.Dispose();
