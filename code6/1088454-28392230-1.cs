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
        public Class1(int number)
        {
            // When we want to set the value of a backing field
            // we use the property we have created for ti
            Number = number;
        }
       
    }
