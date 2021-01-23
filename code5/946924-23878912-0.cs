    string myText = string.Empty;
    using(var reader = new StreamReader(openFileDialog1.FileName))
    {
      string line;
      while((line = reader.ReadLine()) != null)
      {
        myText += YouLogic(line); // use a StringBuilder if the number of string concatenations is high
      }
    }
