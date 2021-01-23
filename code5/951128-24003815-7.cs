    while (tc.IsConnected && prompt != "exit") {
        // display server output
        Console.Write(tc.Read());
        // send client input to server
        prompt = "ehlo a.com";
        tc.WriteLine(prompt);
        // display server output
        consoleout = tc.Read();
        Console.Write(consoleout);
        //send exit input to server
        prompt = "exit";
        tc.WriteLine(prompt);
        Console.Write(tc.Read());
    }
    tc.Close();
    Console.WriteLine("**DISCONNECTED**");
