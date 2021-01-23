    public int Month{ get; private set;} 
    public int Year { get; private set; }
    public void RandomNumberGen()
    {
        Random rnd = new Random();
        Month = rnd.Next(1, 11); // creates a number between 1 and 12
        Year = rnd.Next(1, 21); // creates a number between 1 and 51
    }
