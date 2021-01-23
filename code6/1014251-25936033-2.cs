    public IEnumerable<RowModel> GetRowModels(
        Expression<Func<Row, string>> textExpr)
    {
        return MyDatabaseContext.MyTable.Select(
            textExpr.Combine((row, text) => new RowModel
        {
            RowID = row.ID,
            CreatedDate = row.CreatedDate,
            AnotherProperty = row.AnotherProperty,
            Text = text, // how do I bind this expression?
            Value = row.OtherStuff.Where(os => os.ShouldUse)
                .Select(os => os.Value).FirstOrDefault(),
            AnotherValue = row.OtherStuff.Where(os => os.ShouldUseAgain)
                .Select(os => os.Value).FirstOrDefault()
        }));
    }
