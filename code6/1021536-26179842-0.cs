      String[,] Arr = new String[,] {
        {"A1", "A2", "A3", "A4"},
        {"B1", "B2", "B3", "B4"}
      };
    
      String UserInput = "B3";
    
      for(int line = Arr.GetLowerBound(0); line <= Arr.GetUpperBound(0); ++line)
        for(int column = Arr.GetLowerBound(1); column <= Arr.GetUpperBound(1); ++column)
          if (Arr[line, column].Contains(UserInput)) 
            Arr[line, column] = "X";
