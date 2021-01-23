     public decimal Balance 
     { 
        get { return balance; }
        private set
        {
           if (value < 0)
              throw new ArgumentOutOfRangeException("Only positive values are allowed");
           balance = value;
        }
    }   
