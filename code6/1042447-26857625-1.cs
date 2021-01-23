    public override IEnumerable<Row> Execute(IEnumerable<Row> rows, bool BlockingExecution)
    {
        if (BlockingExecution)
        {
            return rows.ToArray();
        }
        else
        {
            return NonBlockingExecute(rows); // or just "return rows". It seems like the best 
                                             // practice here, in most cases anyway
                                             // would be to move that work elsewhere
        }
     }
        
     private IEnumerable<Row> NonBlockingExecute(IEnumerable<Row> rows)
     {
        foreach (Row row in rows)
        {
            //do some work....
            yield return row;
        }
     }
