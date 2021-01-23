    public Class Bullet 
    {
        // ....
        public int Ychange;
        System.Random rand;
        public Bullet()
        {
            // ....
            rand = new Random();
            Ychange = rand.Next(-3, 3);
        }
        
        // Add the above stuff to your class and constructor 
    }
