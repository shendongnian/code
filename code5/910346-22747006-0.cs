    int keyIn = 0;
    do
    {
        // Check if any key pressed, read it into while-controlling variable
        if (Console.KeyAvailable)
            keyIn = Console.Read();
        // Poll our channel A data
        if (!string.IsNullOrEmpty(inDataA))
        {
            Console.WriteLine(String.Format("Received data {0} on channel A", inDataA));
            inDataA = "";
        }
        // Poll our channel B data
        if (!string.IsNullOrEmpty(inDataB))
        {
            Console.WriteLine(String.Format("Received data {0} on channel B", inDataB));
            inDataB = "";
        }
        // Stop looping when keyIn is no longer 0
    }while (keyIn == 0);
