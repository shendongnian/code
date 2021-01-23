    public void Play(int difficulty)
    {
        while (true)
        {
            HiLow hi = null;
            if (difficulty == 0)      // Easy
            {
                hi = new HiLow(10);
            }
            else if (difficulty == 1) // Medium
            {
                hi = new HiLow(50);
            }
            else if (difficulty == 2) // Hard
            {
                hi = new HiLow(100);
            }
            else if (difficulty == 3) // Much harder
            {
                hi = new HiLow(5000);
            }
            else if (difficulty == 4) // Mwa-ha-ha
            {
                hi = new HiLow(99999999);
            }
            // ...
        }
    }
