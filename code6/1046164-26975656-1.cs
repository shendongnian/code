    if (datatable_results.Rows.Count > 0)
    {
        ConcurrentQueue<string> buffer = new ConcurrentQueue<string>();
        Parallel.ForEach(datatable_results.AsEnumerable(), (data_row, state, index) =>
        {
            // Process data_row as normal.
            // When ready to write to log, do so.
            buffer.Enqueue(string.Format( "Processing row: {0}", index));
        });
        streamwriter.AutoFlush = false;
        string line;
        while (buffer.TryDequeue(out line))
        {
            streamwriter.WriteLine(line);
        }
        streamwriter.Flush();//Flush once when needed
    }
