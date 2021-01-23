    foreach(var item in list)
        if(!item.Processed && Monitor.TryEnter(item.Locker))
            try
            {
                ... // do job
                item.Processed = true;
            }
            finally
            {
                Monitor.Exit(item.Locker))
            }
