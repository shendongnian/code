    delegate int NumberChanger(int n);
    class Program
    {
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultiNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }
        static void Main(string[] args)
        {
            //Create delegate instances
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultiNum);
            //calling the methods using the delegate objects
            nc1(1);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(2);
            Console.WriteLine("Value of Num: {0}", getNum());
            Console.ReadKey();
        }
    }
