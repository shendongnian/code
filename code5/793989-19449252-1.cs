    var client = new POPClient();
    client.Connect("pop.gmail.com", 995, true);
    client.Authenticate("admin@bendytree.com", "YourPasswordHere");
    var count = client.GetMessageCount();
    Message message = client.GetMessage(count);
    Console.WriteLine(message.Headers.Subject);
