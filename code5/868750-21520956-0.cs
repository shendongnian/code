    task.ContinueWith(t =>
    {
        if (t.Exception is AggregateException) // is it an AggregateException?
        {
            var ae = t.Exception as AggregateException;
            foreach (var e in ae.InnerExceptions) // loop them and print their messages
            {
                Console.WriteLine(e.Message); // output is "y" .. because that's what you threw
            }
        }
    },
    TaskContinuationOptions.OnlyOnFaulted);
