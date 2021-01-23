    string[] lines = File.ReadAllLines(@".\path\to\file.txt");
    
    foreach (int i = 0; i < lines.Length; i++)
    {
          string forUser = lines[i];
          // show user the line and let them edit it;
          // somethign like forUser = myTextBoxOrWhatever.Text;
          // do validation if yo uwant
          lines[i] = forUser; // this updates your version of the file with the users changes
          // update display if need be
    }
    
    File.WriteAllLines(@".\path\to\file.txt", lines);
    // this will overwrite the file with the new version
