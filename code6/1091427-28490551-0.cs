    string scene = "";
    
    // iterate your array to construct the scene string
    for (int row = 0; row < 50; row++)
    {
       for (int col = 0; col < 50; col++)
       {
          scene += world[row, col];
       }
       scene += '\n'; // new line
    }
    Console.Clear();  // thanx David
    Console.Write(scene);
