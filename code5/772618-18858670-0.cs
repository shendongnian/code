    private void WriteToFile(TextRange textRange)
    {
        string folderpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "textfile.txt");
        using (StreamWriter oWriter = new StreamWriter(folderpath, true))
        {
            oWriter.WriteLine(DateTime.Now.ToString());
            oWriter.WriteLine("*****************************************************************************");
            oWriter.WriteLine(textRange.Text);
            oWriter.WriteLine("*****************************************************************************");
            oWriter.WriteLine("*****************************************************************************");
            oWriter.Write("$");
        }
        MessageBox.Show(folderpath);
    }
