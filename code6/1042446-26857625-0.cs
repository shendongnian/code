    public override IEnumerable<Row> Execute(IEnumerable<Row> rows, bool BlockingExecution)
    {
        if (BlockingExecution)
        {
            return rows.ToArray();
        }
        else
        {
            return rows;
        }
     }
