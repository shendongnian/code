    public GuessingGame()
    {
        this.Guesses = new List<Guess>();
        this._random = new Random();
        this.Target = new List<int>();
        int randomCount = 3; // how many randoms
        int rndMin = 1; // min value of random
        int rndMax = 10; // max value of random
        for (int i = 0; i < randomCount; i++)
          this.Target.Add(this._random.Next(rndMin, rndMax));
    } 
