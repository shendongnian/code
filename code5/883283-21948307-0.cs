    class Program
    {
        String[] arrUserData = new String[4];// Must specify 4 in brackets for array length, not the same as an index
        // it will fill up as items are added to it starting from position 0 automatically
        // should also be at class level for multiple method access
        public void Play()
        {
            String command; // doesn't need to have an empty string value, only be declared
            String[] arrQuestions = new String[4];//questions asked 
            arrQuestions[0] = "First Name: ";
            arrQuestions[1] = "Last Name: ";
            arrQuestions[2] = "Restaurant Name: ";
            arrQuestions[3] = "Cost of Meal: ";
            do {
                GetString("+ + +  Meal Calculator Exercise  + + +"); // I removed the one in the top of the method, or else it does it twice
                // pass in array of questions to satisfy necessary array argument in GetUserData();
                GetUserData(arrQuestions);//run loop, ask questions populate arrUserData array 
                command = GetString("Again? "); // your GetString method returns whatever the console reads,
                // so it can be assigned to your command variable at the same time, or else the user has to put in y or yes twice
                Console.Clear();
            }
            while (command == "y" || command == "yes");
            GetString("+ + +  Thank you  + + +  Have a wonderful time  + + +  Goodbye!  + + +");
        }
        public String GetString(String strTxt)
        {
            Console.WriteLine(strTxt); return Console.ReadLine().ToLower().Trim();
        }
        // changed it to a void to it just simply assigns the values to the class level array
        public void GetUserData(string[] thisArray)
        {
            for (int i = 0; i < thisArray.Length; i++)//use the passed in array to determine loop length
            {// missing curly braces
                Console.WriteLine(thisArray[i]); // write question with corresponding index to console
                arrUserData[i] = Console.ReadLine(); // use Console.ReadLine to get input and assign it to corresponding index in userData
                if (i == 3) // check for the last index to convert to double
                {// here's the basic way, can cause a lot of errors if user input is not a double
                    Convert.ToDouble(arrUserData[3]);
                    // here's the way trapping all possible errors, and giving a nice message for each
                    // remove the other Convert.ToDouble method and uncomment this to try giving some false values to see how it works
                    /*
                    try
                    {
                        Convert.ToDouble(arrUserData[3]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert " + arrUserData[3] + " to a Double.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine(arrUserData[3] + " is outside the range of a Double.");
                    }
                     * */
                }
            }
            SeeUserData(thisArray); // to display the user data, demonstrates nesting methods that can
            // operate off of one single variable pass in your Play method
            // you could also move it to your play method and change it to SeeUserData(arrQuestions); and it would work the same
        }
        public void SeeUserData(string[] sameArrayAgain)
        {
            Console.WriteLine("Here's the data for " + arrUserData[0]);
            for (int i = 0; i < sameArrayAgain.Length; i++)
            {
                Console.WriteLine("Your " + sameArrayAgain[i] + " " + arrUserData[i]);
            }
        }
        static void Main(string[] args) { Program myProgram = new Program(); myProgram.Play(); }
    }
