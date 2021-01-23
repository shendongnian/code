        char grade;      // one grade
        int aCount = 0, // number of As
            bCount = 0, // number of Bs
            cCount = 0, // number of Cs
               dCount = 0, // number of Ds
               fCount = 0; // number of Fs
        var acceptedGradeCount = 0;
        while(acceptedGradeCount < 10)
        {
            Console.Write("Enter a letter grade: ");
            grade = char.ToLower(Char.Parse(Console.ReadLine()));
            switch (grade)
            {
                case 'a':  // or lowercase a
                    ++aCount;
                    acceptedGradeCount++;
                    break;
                case 'b':  // or lowercase b
                    ++bCount;
                    acceptedGradeCount++;
                    break;
                case 'c': // or lowercase c
                    ++cCount;
                    acceptedGradeCount++;
                    break;
                case 'd':  // or lowercase d
                    ++dCount;
                    acceptedGradeCount++;
                    break;
                case 'f': // or lowercase f
                    ++fCount;
                    acceptedGradeCount++;
                    break;
                default:    // processes all other characters
                    Console.WriteLine(
                       "Incorrect letter grade entered." +
                       "\nEnter a new grade");
                    break;
            } // end switch
        } // end for
        Console.WriteLine(
           "\nTotals for each letter grade are:\nA: {0}" +
           "\nB: {1}\nC: {2}\nD: {3}\nF: {4}", aCount, bCount,
           cCount, dCount, fCount);
