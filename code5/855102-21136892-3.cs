    System.Threading.Thread newThread = new System.Threading.Thread((System.Threading.ThreadStart)delegate {
    //Do whatever you want in a new thread
        while (!cli.Connected)
        {
            //Do something
        }
    });
    newThread.Start(); //Start executing the code inside the thread
    //This code will still run while the newThread is running
    Console.ReadLine(); //Wait for user input
    newThread.Abort(); //Stop the thread when the user inserts any thing
