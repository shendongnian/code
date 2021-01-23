    class Dice
    {
        // event fired when dice is rolled
        public event EventHandler<DiceEventArgs> OnRolled;
        public void Roll(int xTimes)
        {
            int rollNumber = 0;
            var rnd = new Random();
            for (int i = 0; i < xTimes; i++)
            {
                rollNumber++;
                int rdmInt1 = rnd.Next(0, 6);
                int rdmInt2 = rnd.Next(0, 6);
                if (OnRolled != null)
                    OnRolled(null, new DiceEventArgs(rollNumber, rdmInt1, rdmInt2));
                Thread.Sleep(1000);
            }
        }
    }
