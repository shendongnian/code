    var source = new Dictionary<string, Dictionary<String, Object>>();
    foreach (var outerEntry in source)
    {
        foreach (var innerEntry in outerEntry.Value)
        {
            if(innerEntry.Key == "Department")
            {
                // do something
                Console.WriteLine("Key:{0} Value:{1}", innerEntry.Key, innerEntry.Value);
            }
        }
    }
