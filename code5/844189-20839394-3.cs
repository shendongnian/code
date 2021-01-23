    string s = "12/26/2013 17:37:03";
    DateTime dt = DateTime.Now;
    bool success = DateTime.TryParseExact(s, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
    Console.WriteLine("Is Parsing Successful? {0}", success);
    Console.WriteLine(dt);
