     string searchString = txtBoxSH2.Text;
     if (searchString == "")
          return;
     
     foreach (string line in File.ReadLines("C:\\Users\\Sofia\\TestFolder2\\logfile.txt"))
     {
          if (String.IsNullOrWhitespace(line))
               continue;
     
          if (line.Split(' ')[0].ToUpper() == searchString)
               historyLstBox.Items.Add(line);
     }
