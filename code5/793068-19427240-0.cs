    class Green
    {
        public int fact(int num)
        {
            int a;
            int b;
            int c;
            if (num == 1)
            {
                return 1;
            }
            else
            {
                a = num;
                Console.Write(a);
                Console.Write(" #a ");
                return a * fact(num - 1); 
            }
        }
    }
