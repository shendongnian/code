    FileStream inputFileStream = new FileStream("Games.txt", FileMode.Open, FileAccess.Read);
    StreamReader reader = new StreamReader(inputFileStream);
    while (reader.Peek() >= 0)
    {
      var gameName = reader.ReadLine();
      var gameType = reader.ReadLine();
      var gameDifficulty = reader.ReadLine();
      var emptyLine = reader.ReadLine();
      // Here you'll insert the logic to filter out what you want to show.
    }
    inputFileStream.Close();
