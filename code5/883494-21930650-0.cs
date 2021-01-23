    StringBuilder sb = new StringBuilder();
    int counter = 0;
    String path=@"\\MyServer123\MyFolder\MyFile.txt";
    foreach(var line in File.ReadLines(path))
    {
      if (line.Contains(searchstring) && (line.Contains(searchfromdate)))
      {
        sb.AppendLine(line);
        counter++;
      }
    }
    ResultTextBox.Text = sb.ToString();
    CountLabel.Text = counter.ToString();
