     static void Main(string[] args)
            {
                char grade;      // one grade
                int aCount = 0, // number of As
                    bCount = 0, // number of Bs
                    cCount = 0, // number of Cs
                       dCount = 0, // number of Ds
                       fCount = 0; // number of Fs
    
                for (int i = 1; i <= 10; i++)
                {
                    grade = AskForChar(ref aCount, ref bCount, ref cCount, ref dCount, ref fCount); // end switch
                } // end for
                Console.WriteLine(
                   "\nTotals for each letter grade are:\nA: {0}" +
                   "\nB: {1}\nC: {2}\nD: {3}\nF: {4}", aCount, bCount,
                   cCount, dCount, fCount);
            }
    
            private static char AskForChar(ref int aCount, ref int bCount, ref int cCount, ref int dCount, ref int fCount)
            {
                char grade;
                Console.Write("Enter a letter grade: ");
                grade = Char.Parse(Console.ReadLine());
                switch (grade)
                {
                    case 'A': // grade is uppercase A
                    case 'a':  // or lowercase a
                        ++aCount;
                        break;
    
                    case 'B': // grade is uppercase B
                    case 'b':  // or lowercase b
                        ++bCount;
                        break;
    
                    case 'C':  // grade is uppercase C
                    case 'c': // or lowercase c
                        ++cCount;
                        break;
    
                    case 'D': // grade is uppercase D
                    case 'd':  // or lowercase d
                        ++dCount;
                        break;
    
                    case 'F':  // grade is uppercase F
                    case 'f': // or lowercase f
                        ++fCount;
                        break;
                    default:    // processes all other characters
                        Console.WriteLine(
                           "Incorrect letter grade entered." +
                           "\nEnter a new grade");
                        **AskForChar(ref aCount, ref bCount, ref cCount, ref dCount, ref fCount);**
                        break;
                }
                return grade;
            }
