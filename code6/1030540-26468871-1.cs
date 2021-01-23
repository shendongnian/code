    public void BindPractices(DbContext context)
    {
        PracticesBindingSource.DataSource = (
           from p in context.TOWERIMPORTCLIENTs 
           select p.PRACTICE
           ).Distinct().ToArray();
    }
