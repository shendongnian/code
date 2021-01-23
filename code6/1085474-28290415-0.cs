    using (StreamReader sr = new StreamReader(ms))
    {
        do
        {
            var line = sr.ReadLine();
            try
            {
                JObject obj = JsonConvert.DeserializeObject(line) as JObject;
                obj.Dump();
                Console.WriteLine("Foo: {0}", obj["foo"]);
            }
            catch (JsonReaderException jex)
            {
                Console.WriteLine("MALFORMED: {0}", line);
            }
        }
        while (!sr.EndOfStream);
    }
