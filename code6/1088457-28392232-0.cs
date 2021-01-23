       class Class1
        {
            private int number;
    
            public Class1()
            {
            }
    
            public Class1(int number)
            {
                this.number = number;
            }
    
            public int Number
            {
                get
                {
                    return number;
                }
                set
                {
                    if (value > 0)
                        number = value;
                    else
                        number = 0;
                }
            }
        }
