        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 10)
                {
                    _age = value;
                    Console.WriteLine("Value to Small");
                }
                else
                {
                    Console.WriteLine("Value to Big");
                }
            }
        }
