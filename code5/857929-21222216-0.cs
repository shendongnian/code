    void saveOrSaveAs()
    {
      if (File.Exists(fileLabel.Text))
      {
        // this will save in the debug folder unfortunately
        FileStream outputFileStream = new FileStream(fileLabel.Text, FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(outputFileStream);
        // writing block (too long code)
        writer.Close();
        outputFileStream.Close();
      }
      else
      {
        saveAs(); //If You have already written code for saveAs() method.
      }
    }
