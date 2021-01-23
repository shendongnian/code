    int i = 0;
    String testmsg = "This is a 25 char test!!!";
    Byte[] data = System.Text.Encoding.ASCII.GetBytes(testmsg);
    while (true)
    {
        i++;
        testClient.GetStream().Write(data, 0, data.Length);
        if (i % 10 == 0) Console.WriteLine("Cycle Count: " + i);
    }
