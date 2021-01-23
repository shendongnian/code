    int[,] players = new int[22, 3];                      // or [3, 22]
    for (int i = 0; i < 10; i++){
        for (int p = 0; p < players.GetLength(1); p++) {  // or GetLength(0)
            players[i, p] = rand.Next(1, 4);              // or [p, i]
        }
    }
 
