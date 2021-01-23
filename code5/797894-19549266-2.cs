        private void Random()
        {
            RandomNumber random = new RandomNumber();
            int randomInt = random.RandomInRange(1, 5);
 		if (randomInt == 1)
                {
                    lblLabel.ForeColor =  System.Drawing.Color.Red;
                }
                else if (randomInt == 2)
                {
                    lblLabel.ForeColor =  System.Drawing.Color.Yellow;
                }
		else if(randomInt ==3)
                {
			lblLabel.ForeColor =  System.Drawing.Color.White;
                }
                else if (randomInt == 4)
                {
                    lblLabel.ForeColor =  System.Drawing.Color.Blue;
                }
                else if (randomInt == 5)
                {
                    lblLabel.ForeColor =  System.Drawing.Color.Green;
                }
        }
    class RandomNumber
    {
        public int RandomInRange(int l, int u)
        {
            Random generator = new Random();
            return generator.Next(l, u);
        }
    }
