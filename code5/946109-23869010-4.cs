    public async Task ConsumeSomeDataAsync(string sql)
    {
        var hub = new ProducerConsumerHub<IDataRecord>();
        var producerTask = GetSomeDataAsync(sql, rdr => rdr, hub);
        while (true)
        {
            var nextItemTask = hub.ConsumeAsync();
            await Task.WhenAny(producerTask, nextItemTask);
            if (nextItemTask.IsCompleted)
            {
                // process data item
                Console.WriteLine(await nextItemTask);
            }
            if (producerTask.IsCompleted)
            {
                // process the end
                await producerTask;
                break;
            }
        }
    }
