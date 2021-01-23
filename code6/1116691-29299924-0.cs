    Random rand = new Random();
    var availableNumbers = Enumerable.Range(1, 99).ToList();
    var result = new int[3,10];
    
    for(int i = 0; i < 3; i++){
        for(var j = 0; j < 10; j++)
        {
            result[i,j] = availableNumbers
                           .Skip(rand.Next(0, availableNumbers.Count()))
                           .First();
            // Remove used numbers to avoid duplicates:
            availableNumbers.Remove(result[i,j]);
        }
    }
