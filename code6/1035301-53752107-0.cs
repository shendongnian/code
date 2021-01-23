        static void Main(string[] args){
        var intList = new List<int>();
        string sUserInput = "";
        var sList = new List<string>();
        bool validInput = true;
        do
        {
            validInput = true;
            Console.WriteLine("input a space separated list of integers");
            sUserInput = Console.ReadLine();
            sList = sUserInput.Split(' ').ToList();
            try
            {
                foreach (var item in sList) {intList.Add(int.Parse(item));}
            }
            catch (Exception e)
            {
                validInput = false;
                Console.WriteLine("An error occurred. You may have entered the list incorrectly. Please make sure you only enter integer values separated by a space. \r\n");
            }
        } while (validInput == false);
        
        Console.WriteLine("\r\nHere are the contents of the intList:");
        foreach (var item in intList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\r\npress any key to exit...");
        Console.ReadKey();
        }//end main
