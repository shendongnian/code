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
                // process the next data item
                Console.WriteLine(await nextItemTask);
            }
            if (producerTask.IsCompleted)
            {
                // process the end of sequence
                await producerTask;
                break;
            }
        }
    }
