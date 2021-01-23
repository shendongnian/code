    class Cell {
      public int x {get; set;}
      public int y {get; set;} 
      Warrior warrior {get; set;} 
    };
    
    Cell[,] cells = new Cells[6, 6];
    
    // Arrays are zero-based in C#, so they start with 0
    for(int i = 0; i < Cells.GetLength(0); i++) // <- Better get length than put "6"
      for(int j = 0; j < Cells.GetLength(1); j++) 
        cells[i, j] = new Cell() { // <- Do not forget to create Cell
          x = 0, // <- Overshoot, x will be 0 by default, to show the trick only
          y = 0  // <- Overshoot, y will be 0 by default, to show the trick only
        }; 
