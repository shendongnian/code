    SmsClient client = new SmsClient();
    client.Connect();
    System.Threading.Thread.Sleep(5000);
    if (client.SendSms("MyNumber", "XXXXXXXXX", "Hi"))
        Console.WriteLine("Message sent");
    else
        Console.WriteLine("Error");
    client.Disconnect();
    Console.ReadLine();
