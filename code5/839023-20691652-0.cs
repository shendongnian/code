    class AdditionOdMultipleNum
    {
        public AdditionOdMultipleNum(int a)
        {
            Init(a);
        }
        public AdditionOdMultipleNum(int a, int b)
        {
            Init(a, b);
        }
        public AdditionOdMultipleNum(int a, int b, int c)
        {
            Init(a, b, c);
        }
        private void Init(int a)
        {
            Console.WriteLine("sum of {0},1 is : {1}", a, (a + 1));
        }
        private void Init(int a, int b)
        {
            Console.WriteLine("sum of {0},{1} is : {2}", a, b, (a + b));
            Init(a);
        }
        private void Init(int a, int b, int c)
        {
            Console.WriteLine("sum of {0},{1},{2} is : {3}", a, b, c, (a + b + c));
            Init(a, b);
        }
    }
