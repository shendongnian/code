    int[][] players = new[] { new int[22], new int[22], new int[22] };
    for (int i = 0; i < 10; i++){
        for (int p = 0; p < players.Length; p++) {
            players[p][i] = rand.Next(1, 4);
        }
    }
