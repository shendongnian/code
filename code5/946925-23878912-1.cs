    string myText = string.Empty;
    using(var reader = new BinaryReader(openFileDialog1.FileName))
    {
      string line;
      while((line = reader.ReadString()) != null)
      {
        myText += YouLogic(line); // use a StringBuilder if the number of string concatenations is high
      }
    }
