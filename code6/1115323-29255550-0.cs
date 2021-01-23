    class Omega
    {
        private OInterface iDontKnowHowToNameIt;
        public Omega(int value)
        {
            if (value == 1)
                iDontKnowHowToNameIt = new Alpha();
            else if (value == 2)
                iDontKnowHowToNameIt = new Beta();
            else
                throw new ArgumentException("Wrong value passed");
        }
    }
