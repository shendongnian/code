    foreach (string key in webResponse.Headers.Keys)
    {
        if (key != "Location")
        {
            var value = webResponse.Headers[key];
            Console.WriteLine("{0}: {1}", key, value);
        }
    }
