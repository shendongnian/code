    static void Main(string[] args)
    {
        int num1 = 4;
        int num2 = 7;
        
        for (int i = 200; i < 2000; i++)
        {
            if(i>220)
               break;
            if ((i % num1 == 0) && (i % num2 ==0))
            {
                Console.WriteLine(i);
            }
        }
        Console.Read();
    }
