    static int IntCheck(string num)
    {
        int value;
        int NewValue;
        if (!int.TryParse(num, out value))
        {
            Console.WriteLine("I am sorry, I thought I said integer, let me check...");
            Console.WriteLine("Checking...");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Yup, I did, please try that again, this time with an integer");
            NewValue = IntCheck(Console.ReadLine());
        }
        else
        {
            NewValue = value;
        }
        return NewValue;
     }
