    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "textfile.txt");    
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
    {
        //if the file doesn't exist, create it
        if (!File.Exists(fileName))
            File.Create(fileName);
    
        for (int i = 0; i < res2.Count(); i++)
        {
            label3.Text = "Updating ... ";
            label3.Visible = true;
            label3.Refresh();
            file.WriteLine("asdasD");
        }
        
        file.Close();
    }
