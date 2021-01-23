        public static int InputMembershipStatus()
        {
            int age = 0;
            Console.WriteLine("Are you a Club Member? <Y or N>: ");
            string aValue = Console.ReadLine();
            if (aValue == "Y" || aValue == "y" || aValue == "Yes" || aValue == "yes")
            {
                age = InputAge();
            }
            else if (aValue == "N" || aValue == "n" || aValue == "No" || aValue == "no")
            {
                Console.WriteLine("Sorry, discounts apply to Club Members only.");
                TerminateProgram();
            }
            return age;
        }
