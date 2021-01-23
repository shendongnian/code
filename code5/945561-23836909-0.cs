    private static void Main()
    {
        using (var client = new ServiceClient())
        using (var scope = new OperationContextScope(client.InnerChannel))
        {
            MessageHeader usernameTokenHeader = MessageHeader.CreateHeader("UsernameToken",
                "http://test.com/webservices", "username");
            OperationContext.Current.OutgoingMessageHeaders.Add(usernameTokenHeader);
    
            MessageHeader passwordTextHeader = MessageHeader.CreateHeader("PasswordText",
                "http://test.com/webservices", "password");
            OperationContext.Current.OutgoingMessageHeaders.Add(passwordTextHeader);
    
            MessageHeader sessionTypeHeader = MessageHeader.CreateHeader("SessionType",
                "http://test.com/webservices", "None");
            OperationContext.Current.OutgoingMessageHeaders.Add(sessionTypeHeader);
    
            string result = client.GetData(1);
            Console.WriteLine(result);
        }
        Console.ReadKey();
    }
