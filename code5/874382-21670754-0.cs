     public enum PersonIntial
        {
            Person1,
            Person2,
            Person3,
            All
        }
        public int Person1Acnt { get; set; }
        public int Person2Acnt { get; set; }
        public int Person3Acnt { get; set; }
        public int TotalSales { get; set; }
        private void ProcessInput(PersonIntial pInitail, int amount)
        {
            switch (pInitail)
            {
                case PersonIntial.Person1:
                    {
                        Person1Acnt += amount;
                    }
                    break;
                case PersonIntial.All:
                    {
                        TotalSales = Person1Acnt + Person2Acnt + Person3Acnt;
                    }
                    break;
            }
        }
