    private Random _random;
    public GuessingGame()
    {
        this.Guesses = new List<Guess>();
        this.Target = new List<int>() { 1, 2, 3 };
        this._random = new Random(DateTime.Now.Millisecond);  
        for(int i=0;i<10;i++)
        {
         this.Target.Add(this._random.Next(0,10));
        }
    
              
    }
    
    public List<int> Target { get; set; }
    public List<Guess> Guesses { get; set; }
