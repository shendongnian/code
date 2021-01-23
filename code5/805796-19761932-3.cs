       private int _age;
    
            public int Age
            {
                get { return _age; }
                set
                {
                    _age = value;
    
                    Console.WriteLine(_age < 10 ? "Value to Small" : "Value to Big");
                }
            }
    
            private static void Main(string[] args)
            {
                var banmeet = new Program();
                banmeet.Age = 22;
                Console.ReadLine();
            }
