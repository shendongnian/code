    bool isCorrectTime = false;
    while(!isCorrectTime) // The "!" is for NOT
    {
        try
        {
            Console.WriteLine("Incorrect format please type your birthday again(dd-mm-yyyy)");
            startdate = Console.ReadLine();
            isCorrectTime = true; //If we are here that means that parsing the DateTime
            // did not throw errors and therefore your time is correct!
        }
        catch
        {
            //We leave the catch clause empty as it is not needed in this scenario
        }
    }
