        static void Main(string[] args)
        {
            Class1 cl = new Class1();
            cl.MySTR = "A";
            func1(cl);
            Console.WriteLine(cl.MySTR);
             func2(ref cl);
             Console.WriteLine(cl.MySTR);
             Console.ReadLine();
        }
        private static void func1(Class1 cla)
        {
            cla = new Class1();
            cla.MySTR = "B";
        }
        private static void func2(ref Class1 clas)
        {
            clas.MySTR = "C";
        }
    }
    public class Class1
    {
        public string MySTR;
       
    }
