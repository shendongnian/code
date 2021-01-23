    StringWriter writer = new StringWriter();
    Random rand = new Random();
    for (int i = 0; i < 100; i++)
    {
        int x = 0;
        x = rand.Next(32, 126);
        writer.Write((char)x);
    }
    writer.Close();
    string s = writer.ToString();
    File.WriteAllText(@"C:\temp\so2343.dat", s, Encoding.ASCII);
