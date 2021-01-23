    // My suggestion of unsortedList generic type
    public struct Winner {
      public int WinnerScore;
      public String WinnerName; 
    }
    
    ...
    
    // 1. You shoud create unsortedList:
    List<Winner> unsortedList = new List<Winner>(); 
    
    // 2. You should also initialize the list with Winner instances
    for (int u = 0; u < nWinners; ++u)
      unsortedList.Add(new Winner());
    
    // 3. Only that you can fill unsortedList from file.
    //    And you original code becames the correct one
    using (StreamReader sr = new StreamReader("highscores.txt")) {
      for (int u = 0; u < nWinners; ++u) {
        unsortedList[u].WinnerScore = int.Parse(sr.ReadLine()); 
        unsortedList[u].WinnerName = sr.ReadLine(); 
      } 
    }
