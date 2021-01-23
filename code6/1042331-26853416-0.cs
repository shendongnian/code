    class Addition
    {
        public int P1 {get;set;}
        public int P2 {get;set;}
        public long varSum {get;set;}
        
        public void Addition (int P1, int P2)
        {
            this.P1 = P1; 
            this.P2 = P2;
            this.varSum = P1 + P2;
        }
    }
