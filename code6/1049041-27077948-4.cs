    public partial class YourEfContext : DbContext 
    {
        .... (other EF stuff) ......
        // get your EF context
        public int GetNextSequenceValue()
        {
            var rawQuery = Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TestSequence;");
            var task = rawQuery.SingleAsync();
            int nextVal = task.Result;
            return nextVal;
        }
    }
