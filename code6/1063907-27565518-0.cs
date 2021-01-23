    using(Pop3Client client = new Pop3Client())
    {
        client.Connect(hotmailHostName, pop3Port, useSsl);
        client.Authenticate(username, password, AuthenticationMethod.UsernameAndPassword);
        // And here you can use the client.GetMessage() method to get a desired message. 
        // You can iterate all the messages and check properties on each of them. 
    }
