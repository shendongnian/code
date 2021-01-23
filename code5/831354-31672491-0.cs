        //Declare array
        const int iWEEK = 7;
        string[] sDays = new string[iWEEK] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        //Display the days of the week
        for (iDays = 0; iDays < iWEEK; iDays++)
        {
            Console.WriteLine("The day of the week is " + sDays[iDays]);
        }
        //Prevent program from closing
        Console.WriteLine();
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
