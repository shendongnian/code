        static void Main(string[] args)
        {
            int[] test = new int[5];
            test[0] = 10;
            test[1] = 20;
            test[2] = 40;
            test[3] = 80;
            addFirst(123, test.Length, test);
            foreach(int i in test)
            {
                Console.WriteLine(i);
            }
           
        }
        public static void addFirst(int value, int count, int[] test) 
        {
            //Check for full list done by you already
            for (int i = count-1; i > 0; i--)
            {
                test[i] = test[i-1];
            }
            test[0] = value;
        }
