    var reader = new JsonTextReader(Console.In);
    reader.SupportMultipleContent = true;
    var serializer = new JsonSerializer();
    while (reader.Read())
    {
        try
        {
            var message = serializer.Deserialize<string>(reader);
            Console.WriteLine("Got message: {0}", message);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
