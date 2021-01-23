    List<string> listOfString = new List<string>;
    for (int i = 0; i <= filesToRead.Count; i++)
    {
          using (var reader = new StreamReader(filesToRead[i]))
          {
               string line;
               while ((line = reader.ReadLine()) != null)
               {
                 listOfString.add(line);
               }
          }
    }
