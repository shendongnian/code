    class Class1
    {
        private int num;
    
        public Class1(int number)
        {
            Number = number;
        }
        public int Number
        {
            get 
            { 
                return num;
            }
            set
            {
                if (value > 0)
                    num = value;
                else
                    num = 0;
            } 
        }
    }
