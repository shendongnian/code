    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static string[] talents = { "Dancing", "Musical", "Other" };
            public static char[] validTalentCodes = { 'D', 'M', 'O' };
            public static string[] contestantNames;
            public static char[] contestantTalentCodes;
            static void Main()
        {
            int pastContestants;
            int currentContestants;
            // Call Methods:
            Console.Write("LAST YEAR'S TALENT:  ");
            pastContestants = Contestants();
            Console.Write("THIS YEAR'S TALENT:  ");
            currentContestants = Contestants();
            Overview(pastContestants, currentContestants);
            CompetitorTalents(currentContestants);
            // need to call the TalentListing Method...
            TalentListing();
            Console.ReadLine();         
         }
            public static int Contestants()
            { // Get & returns valid # of contestants.  Called twice - last year & this year
                int contestants = 0; // holds return value
                const int MIN = 0;  // will allow 0 as an answer
                const int MAX = 30;  // will allow 30 as an answer          
                Console.Write("Please enter the number of contestants:  ");
                contestants = Int32.Parse(Console.ReadLine());
                while (contestants < MIN || contestants > MAX)
                {
                    Console.Write("Invalid number.  Please enter a number between 0 and 30, inclusive:  ");
                    contestants = Int32.Parse(Console.ReadLine());
                }
                return contestants;
            }
            public static void Overview(int past, int current)
            { // Accepts contestant - past & current.  Displays 1 of 3 messages.
                double entranceFee = 25.00;
                Console.WriteLine("\nWe had {0} contestants last year and have {1} contestants this year.", past,
                                   current);
                //if more than double
                if (current > (past * 2))
                    Console.WriteLine("The competition is more than twice as big this year!");
                //if bigger but no more than double
                if (current > past && current < (past * 2))
                    Console.WriteLine("The competition is bigger than ever!");
                //if smaller than last year
                if (current < past)
                    Console.WriteLine("A tighter race this year.  Come out and cast your vote!");
                Console.WriteLine("\nThe revenue expected for this year is {0:C}.", current * entranceFee);
            }
            public static void CompetitorTalents(int current)
            { // Fill array of competitors and their talent codes.
                string contestantNameEntered;// user entry
                char talentCodeEntered; // user entry
                int[] total = new int[talents.Length];
                bool validCode = false;
                int counter = 0;
                contestantNames = new string[current]; // set array size
                contestantTalentCodes = new char[current]; // set array size
                // put contestants in array
                while (counter < current)// loop for all contestants
                {
                    // get contenstants name and put in array
                    Console.Write("Please enter the name of contestant:   ");
                    contestantNameEntered = Console.ReadLine();
                    counter += 1; // contestant number
                    validCode = false;
                    //place in correct array element
                    contestantNames[counter - 1] = contestantNameEntered;
                    // get contestants talent code, verify and place in array
                    while (validCode == false) // reset per contestant
                    {
                        Console.Write("Please enter the contestant's talent code (D=Dancing, M=Musical, O=Other):  ");
                        talentCodeEntered = Char.Parse(Console.ReadLine().ToUpper());  // convert to uppercase
                        for (int x = 0; x < validTalentCodes.Length && !validCode; ++x)
                            if (talentCodeEntered == validTalentCodes[x]) // talent code valid?
                            {
                                validCode = true; // true if match found
                                contestantTalentCodes[counter - 1] = talentCodeEntered; //put talent code in array
                                x = validTalentCodes.Length;  // breaks out of loop
                            }
                        if (validCode == false)  // false if no match found = invalid code.
                        {
                            Console.WriteLine("Invalid code talent Code.");
                        }
                    }
                }
                // search all elements of validTalentCodes array (D, M, O), count instances in contestantTalentCodes array
                for (int z = 0; z < validTalentCodes.Length; z++) // validTalentCodes
                    for (int x = 0; x < contestantTalentCodes.Length; x++) // contestantTalentCodes
                        if (contestantTalentCodes[x] == validTalentCodes[z])
                        {
                            total[z]++;
                        }
                for (int x = 0; x < talents.Length; ++x)
                    Console.WriteLine("Total contenstants for {0} is {1}.", talents[x], total[x]);
                return ;
            }
            /// Continuously prompt for talent codes and display contestants with the corresponding talent until quit.
            /// What talent code would you like to see (or QUIT)?
            public static void TalentListing()
            { 
                const char QUIT = 'Q';// must be upper as char are converted!!
                char userOption = ' ';
                bool validCode = false;
                while (userOption != QUIT)
                {
                    Console.Write("\nWhat talent code would you like to view? (D, M, O or Q to quit):  ");
                    validCode = false;  // reset from previous section
                    userOption = Char.Parse(Console.ReadLine().ToUpper());
                    for (int x = 0; x < contestantNames.Length && !validCode; ++x)
                    {
                        if (userOption == validTalentCodes[x]) // valid talent code?
                        {
                            validCode = true;
                            Console.Write("The contestants in {0} talent are: ", validTalentCodes[x]);
                            // display list of contestants with that code
                            for (int z = 0; z < contestantTalentCodes.Length; z++) // validTalentCodes
                                if (contestantTalentCodes[z] == userOption)
                                {
                                    Console.Write("\n{0}", contestantNames[z]);
                                }
                        }
                    }
                    if (validCode == false)
                        Console.WriteLine("Invalid talent code!");
                }
                Console.WriteLine();  // when QUIT is selected
            }
        }
    }
