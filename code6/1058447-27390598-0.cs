    //method that listens for commands from the GUI and parses them
    static void pipe_client(string[] args)
    {
        string parentSenderID;
        //get pipe handle id
        parentSenderID = args[0];
        //create streams
        var receiver = new AnonymousPipeClientStream(PipeDirection.In, parentSenderID);
        
        using (StreamReader sr = new StreamReader(receiver))
        {
                    // Display the read text to the console 
                    string temp;
                    // wait for message from server.
                    do
                    {
                        Console.WriteLine("waiting for message...");
                        temp = sr.ReadLine();
                    }
                    while (!<temp in some check variable or array>);
                    
                    switch(temp)
                    { 
                       handle everything here.  
                    }
        }
    }
