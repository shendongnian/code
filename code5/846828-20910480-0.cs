            public string TestString
        {
            get { return TestString; }
         
            set 
            {
                if(!string.IsNullOrEmpty(value))
                {
                    // TODO: Add your logic to check if exists somwhere
                    TestString = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", " etc... ");
                }
            } 
        
        }
