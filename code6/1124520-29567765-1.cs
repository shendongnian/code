    private static void Main()
    {
        double years = GetDoubleFromUser("Enter the duration of the loan (in years): ");
        double principal = GetDoubleFromUser("Enter the princple ammount: ");
        double rate = GetDoubleFromUser("Enter the interest rate: ") / 100;
        Console.WriteLine("\nBased on these values entered:");
        Console.WriteLine(" - Number of years .... {0}", years);
        Console.WriteLine(" - Principal amount ... {0:c}", principal);
        Console.WriteLine(" - Interest rate ...... {0:p}", rate);
        double monthlyRate = rate / 12;
        double payments = 12 * years;
        double result =
            principal *
            (monthlyRate * Math.Pow(1 + monthlyRate, payments)) /
            (Math.Pow(1 + monthlyRate, payments) - 1);
        Console.WriteLine("\nYour monthly payment will be: {0:c}", result);
        Console.ReadLine();
    }
