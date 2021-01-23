    private class Tripple
    {
        public int PrevAntenna { get; set; }
        public int NumOfTimesSeen { get; set; }
        public Timer Timer { get; set; }
    
        // ctor
        public Tripple(int antenna, Timer tm)
        {
            this.PrevAntenna = antenna;
            this.NumOfTimesSeen = 1;
            this.Timer = tm;
        }
    } 
