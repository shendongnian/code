    static void Main(String[] args)
        {
            int option = 1;
            int num1 = 0;
            int num2 = 0;
            int sum = 0;
            DisplayMenu();
            while (option != 0)
            {
                option = GetUserOption();
                switch (option)
                {
                    case 1:
                        num1 = getNum(option);
                        break;
                    case 2:
                        num2 = getNum(option);
                        break;
                    case 3:
                        Overall(num1, num2, sum);
                        break;
                }
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("1: Num1, 2: Num2, 3: Overall, 0: Exit");
        }
        static int GetUserOption()
        {
            Console.WriteLine("Pick choice");
            return Convert.ToInt32(Console.ReadLine());
        }
        static int getNum(int option)
        {
            if (option == 1)
                Console.WriteLine("Enter your first number");
            else
                Console.WriteLine("Enter your second number");
            return Convert.ToInt32(Console.ReadLine());
        }
        static int Overall(int num1, int num2, int sum)
        {
            Console.WriteLine("This will add the two together");
            sum = num1 + num2;
            Console.WriteLine(sum);
            return sum;
        }
