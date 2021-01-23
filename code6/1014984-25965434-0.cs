    double interestRate;
        public double InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                if (value >= 0)
                {
                    interestRate = value;
                }
                else
                {
                    interestRate = 0;
                }
            }
        }
