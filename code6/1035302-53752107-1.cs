        do
        {
            validInput = true;
            Console.WriteLine("input a space separated list of integers");
            sUserInput = Console.ReadLine();
            sList = sUserInput.Split(' ').ToList();
            if (sList.Count > 5)
            {
                validInput = false;
                Console.WriteLine("you entered too many integers. You must enter only 5 integers. \r\n");
            }
            else
            {
                try
                {
                    foreach (var item in sList) { intList.Add(int.Parse(item)); }
                }
                catch (Exception e)
                {
                    validInput = false;
                    Console.WriteLine("An error occurred. You may have entered the list incorrectly. Please make sure you only enter integer values separated by a space. \r\n");
                }
            }
            
        } while (validInput == false);
