        static void Main(string[] args)
        {
            key = new int[100, 50];
            var d0 = key.GetLength(0);
            var d1 = key.GetLength(1);
            System.Random random = new System.Random();
           
            for (int i = 0; i < d0; ++i)
                for (int j = 0; j < d1; ++j)
                    key[i, j] = random.Next();
            
            Console.WriteLine(myfunc(3, 5));
        }
