        private static string testT = "test line to have an address";
         static void Main(string[] args)
        {
            Test(testT);
        }
        static unsafe void Test(string str)
        {
            fixed (char* pfixed = str)
            {
                int i = (int)pfixed;
                int* p = (int*)i;
                int* c = p;
            }
        }
