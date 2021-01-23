    class Program
    {
        [DllImport("c:\\PathToMyDllOrExeFile\\MyAddDll.dll")]
        public static extern int Add(int val1, int val2);
        static void Main(string[] args)
        {
            int val1 = 12;
            int val2 = 4;
            Console.WriteLine("{0} + {1} = {2}", val1, val2, Add(val1, val2));
        }
    }
