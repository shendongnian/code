        int result = 0;
        int caseSwitch = new Random().Next(1, 4);
        string question = DoMultiplication(out result);
        Console.WriteLine(question);
        int answer = Convert.ToInt32(Console.ReadLine());
        if (answer == result)
        {
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Very Good");
                    break;
                case 2:
                    Console.WriteLine("Excellent");
                    break;
                case 3:
                    Console.WriteLine("Nice Work");
                    break;
                case 4:
                    Console.WriteLine("Keep up the good work!");
                    break;
            }
        }
        else
        {
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("No, Please Try Again.");
                    break;
                case 2:
                    Console.WriteLine("Wrong, Try Once More");
                    break;
                case 3:
                    Console.WriteLine("Don't Give Up!");
                    break;
                case 4:
                    Console.WriteLine("No, Keep Trying!");
                    break;
