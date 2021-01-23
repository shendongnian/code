        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age < 10)
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
        private static void Main(string[] args)
        {
            var banmeet = new Program();
            banmeet.Age = 22;
            Console.ReadLine();
        }
