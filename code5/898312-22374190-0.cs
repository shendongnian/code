        class MultipleVariable
    {
        public int  var1,var2,var3,var4,var5;
    };
    class Program
    {
        static void Main(string[] args)
        {
            MultipleVariable mv = new MultipleVariable();
            mv.var1 = 10;
            mv.var2 = 20;
            mv.var3 = 30;
            mv.var4 = 40;
            mv.var5 = 50;
            Console.WriteLine(mv.var1 + mv.var2 + mv.var3 + mv.var4 + mv.var5);
        }
    }
