    for (; ; )
    {
           Console.WriteLine("Give a number to select a colour between 0-15? ");
           ConsoleColor renk;
           int num;
           string strNum = Console.ReadLine();
           if(int.TryParse(strNum, out num) && (num >= 0 && num <= 15))
           {
                Console.BackgroundColor = (ConsoleColor)num;
                Console.Clear();
           }
           else
           {
                 Console.WriteLine("Error");
           }  
    }
