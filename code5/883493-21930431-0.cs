    string line;
    string path = @"\\server1\TextFolder\Text.txt";
    StringBuilder sb = new StringBuilder();
    int counter = 0;
    
    using (StreamReader file = new StreamReader(path))
    {
      while ((line = file.ReadLine()) != null)
          {
             if (line.Contains(searchstring))
              {
                   if (line.Contains(searchfromdate)) //|| line.Contains(searchtodate)) 
                      {
                            sb.AppendLine(line.ToString());
                            counter++;
                      }
              }
          }
    }
    
    ResultTextBox.Text = sb.ToString();
    CountLabel.Text = counter.ToString();
