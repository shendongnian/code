    HttpResponseMessage response = await client.GetAsync("api/yourUrl");
    
    if (response.IsSuccessStatusCode)
    {
        IEnumerable<RootObject> rootObjects =
            awaitresponse.Content.ReadAsAsync<IEnumerable<RootObject>>();
        foreach (var rootObject in rootObjects)
        {
            Console.WriteLine(
                "{0}\t${1}\t{2}",
                rootObject.Data1, rootObject.Data2, rootObject.Data3);
        }
        Console.ReadLine();
    }
