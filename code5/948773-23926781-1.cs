    class Whatever
    {
        private int extraLifeRemainder;
        private int totalScore;
        public int TotalScore
        {
            get { return totalScore; }
            set
            {
                int increment = (value - totalScore);
                DoIncrementExtraLife(increment);
                totalScore = value;
            }
        }
        public int ExtraLife { get; set; }
        private void DoIncrementExtraLife(int increment)
        {
            if (increment > 0)
            {
                this.extraLifeRemainder+= increment;
                int rem;
                int quotient = Math.DivRem(extraLifeRemainder, 5, out rem);
                this.ExtraLife += quotient;
                this.extraLifeRemainder= rem;
            }
        }
    }
    private static void Main()
    {
        Whatever w = new Whatever();
        w.TotalScore += 8;
        w.TotalScore += 3;
        Console.WriteLine("TotalScore:{0}, ExtraLife:{1}", w.TotalScore, w.ExtraLife);
        //Prints 11 and 2
    }
 
