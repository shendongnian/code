    public void updateAllResults()
    {
        var tasks = PairList.Select(async (item) => 
        {
            var data = await Parse.JsonParse<PairResults>
                .getJsonString("http://localhost:22354/" + item.Original).
                .ConfigureAwait(false);
            item.part1 = data.value;
        });
		Task.WaitAll(tasks.ToArray());
    }
