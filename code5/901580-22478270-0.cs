        static void Main(string[] args)
        {
            List<Dur> fList = new List<Dur>();
            fList.Add(new Dur(10));
            fList.Add(new Dur(11));
            fList.Add(new Dur(12));
            fList.Add(new Dur(13));
            List<Sec> sList = new List<Sec>();
            sList.Add(new Sec(20));
            sList.Add(new Sec(22));
            sList.Add(new Sec(11));
            sList.Add(new Sec(10));
            sList.Add(new Sec(25));
            var result = from x in fList
                      join y in sList on x._x equals y._y
                      select x._x;
            var sum = result.Sum();
            Console.Write(sum);
            Console.ReadKey();
        }
    }
    class Dur
    {
        public Dur(int x)
        {
            _x = x;
        }
        public int _x;
    }
    class Sec
    {
        public Sec(int y)
        {
            _y = y;
        }
        public int _y;
    }
