    try
    {
      foreach (var file in Directory.GetFiles(spcdirectorypath))
      {
        richTextBox1.AppendText(file + "\r\n");
      }
    }
    catch (IOException)
    {
      richTextBox1.AppendText("Failed " + spcdirectoryPath + "\r\n");
    }
