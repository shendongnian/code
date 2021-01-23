    var block = new ActionBlock<string>(url =>
        {
            var stream = (await WebRequest.CreateHttp(url).GetResponseAsync()).GetResponseStream();
            using (var fileStream = new FileStream("blabla", FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }
        },
        new ExecutionDataflowBlockOptions
        {
            MaxDegreeOfParallelism = 100,
        });
