    result.ToList().ForEach(item =>
    {
        var i = 0;
        foreach (var url in item.Urls)
        {
            Debug.WriteLine("{0}, {1}, {2}", item.Title, item.Id, url);
            Debug.WriteLine(url.GetType());
            Debug.WriteLine("i : " + i++);
        }
    });
