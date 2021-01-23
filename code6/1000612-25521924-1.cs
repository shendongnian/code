    public const int BULK_AMOUNT = 10;
    private async void ProcessSqlData()
    {
        List<Item> lstItems = await UnitOfWork.Items.GetAllAsync();
        for (var i = 0; i < lstItems.Count; i += BULK_AMOUNT)
        {
            // Running the process parallel with to many items
            // might slow down the whole process, so just take a bulk
            var bulk = lstItems.Skip(i).Take(BULK_AMOUNT).ToArray();
            var tasks = new Task[bulk.Length];
            for (var j = 0; j <= bulk.Length; j++)
            {
                // Create and start tasks, use ProcessItemsAsync as Action
                tasks[j] = Task.Factory.StartNew(() => ProcessItemsAsync(bulk[j], 0));
            }
            // Wait for the bulk to complete
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException e)
            {
                Log.WriteLine(String.Format(
                    "The maximum amount of retries has been exceeded in bulk #{0}. Error message: {1}",
                    i,
                    e.InnerException != null
                        ? e.InnerException.Message
                        : e.Message));
            }
        }
    }
