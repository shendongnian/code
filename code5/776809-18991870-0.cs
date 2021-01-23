    var numberOfConcurrentMoves = 2;
    var moves = new List<Task>();
    var sourceDirectory = "source-directory";
    var destinationDirectory = "destination-directory";
    
    foreach (var filePath in Directory.EnumerateFiles(sourceDirectory))
    {
        var move = new Task(() =>
        {
            File.Move(filePath, Path.Combine(destinationDirectory, Path.GetFileName(filePath)));
    
            //UPDATE DB
        }, TaskCreationOptions.PreferFairness);
        move.Start();
    
        moves.Add(move);
    
        if (moves.Count >= numberOfConcurrentMoves)
        {
            Task.WaitAll(moves.ToArray());
            moves.Clear();
        }
    }
    
    Task.WaitAll(moves.ToArray());
