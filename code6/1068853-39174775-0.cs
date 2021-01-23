    using System.Collections.Async;
    await messagesByFromNumber.ParallelForEachAsync(async messageGroup =>
    {
        foreach (var message in messageGroup)
        {
            await message.SendAsync();
        }
    }, maxDegreeOfParallelism: 10);
