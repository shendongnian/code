    try {
        if (something)
        {
            //some code
            if (something2)
            {
                throw new Exception("Weird-01.");
                // now You will go to the catch statement
            }
            if (something3)
            {
                throw new Exception("Weird-02.");
                // now You will go to the catch statement
            }
            //some code
            return;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex); // you will get your Weird-01 or Weird-02 here
    }
    // The code i want to go if the second or third if is true
