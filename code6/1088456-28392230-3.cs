    class Class1
    {
        // The backing field has the same name as the Property
        // but all letters must be lowercase.
        private int number;
        
        public int Number
        {
            get { return number; }
            set
            {
                if (value > 0)
                    number = value;
                else
                    number = 0;
            } 
        }
        // In the constructor we set the value of the backing fields
        // using the corresponding properties.
        public Class1(int number)
        {
            Number = number;
        }
    }
